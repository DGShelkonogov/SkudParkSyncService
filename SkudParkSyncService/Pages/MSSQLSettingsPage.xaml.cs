using Newtonsoft.Json;
using SkudParkSyncService.Models;
using SkudParkSyncService.Services;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SkudParkSyncService.Pages
{
    public partial class MSSQLSettingsPage : Page
    {
        private ObservableCollection<ServerType> _serverTypes = new ObservableCollection<ServerType>()
        {
            ServerType.LOCAL,
            ServerType.REMOTE
        };

        public MSSQLSettingsPage()
        {
            InitializeComponent();
            cmbServerType.ItemsSource = _serverTypes;
            gridUserPassword.IsEnabled = false;
            FillFields();
        }

       
        public SqlConnectionStringBuilder СreateSqlConnectionStringBuilder()
        {
            var connectionString = new SqlConnectionStringBuilder()
            {
                InitialCatalog = txtServerName.Text,
                DataSource = txtAddress.Text
            };
            if (radioButtonWindows.IsChecked == true)
            {
                connectionString.IntegratedSecurity = true;
            }
            else
            {
                connectionString.UserID = txtUsername.Text;
                connectionString.Password = txtPassword.Password;
            }
            return connectionString;
        }


        private async void ButtonClickCheckConnection(object sender, RoutedEventArgs e)
        {
            var window = (MainWindow)Window.GetWindow(this);
            try
            {
                var connectionStringBuilder = СreateSqlConnectionStringBuilder();

                await Task.Run(() => {
                    var connection = new SqlConnection(connectionStringBuilder.ConnectionString);
                    connection.Open();
                    connection.Close();
                });

                window.EditMSSSQLonnectionStatus(DBConnectionStatus.OPEN);
                txtMessageLog.Text = "Подключение прошло успешно";
                txtMessageLog.Foreground = Brushes.Green;
            }
            catch (Exception ex)
            {
                window.EditMSSSQLonnectionStatus(DBConnectionStatus.MISSING);
                txtMessageLog.Text = ex.Message;
                txtMessageLog.Foreground = Brushes.Red;
            }
        }


        private async void ButtonClickAccept(object sender, RoutedEventArgs e)
        {
            var connectionStringBuilder = СreateSqlConnectionStringBuilder();

            var result = JsonConvert.SerializeObject(connectionStringBuilder);
            await MSSQLConnection.SaveConnectionString(result);

            var window = (MainWindow)Window.GetWindow(this);
            await window.CheckMSSQLConnectionStatus();
        }


        private void CmbServerTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedServerType = (ServerType)cmbServerType.SelectedItem;

            if (selectedServerType == ServerType.REMOTE)
            {
                txtAddress.IsEnabled = true;
            }
            else
            {
                txtAddress.IsEnabled = false;
                txtAddress.Text = "localhost";
            }
        }


        public void FillFields()
        {
            try
            {
                if (File.Exists(MainWindow.PathToAppsettings))
                {
                    string json = File.ReadAllText(MainWindow.PathToAppsettings);
                    dynamic jsonObj = JsonConvert.DeserializeObject(json);
                    string connectionString = jsonObj["WorkerOptions"]["ParkDbConnectionString"];
                    var result = JsonConvert.DeserializeObject<SqlConnectionStringBuilder>(connectionString);

                    txtUsername.Text = result.UserID;
                    txtPassword.Password = result.Password;
                    txtServerName.Text = result.InitialCatalog;
                    txtAddress.Text = result.DataSource;

                    radioButtonWindows.IsChecked = result.IntegratedSecurity;
                    radioButtonNamePassword.IsChecked = !result.IntegratedSecurity;

                    if (txtAddress.Text != "localhost" && txtAddress.Text != "127.0.0.1")
                        cmbServerType.SelectedItem = ServerType.REMOTE;
                }
            }
            catch (Exception e)
            {

            }
        }

        private void radioButtonCheckedWindows(object sender, RoutedEventArgs e)
        {
            if(gridUserPassword != null)
                gridUserPassword.IsEnabled = false;
        }

        private void RadioButtonCheckedNamePassword(object sender, RoutedEventArgs e)
        {
            if (gridUserPassword != null)
                gridUserPassword.IsEnabled = true;
        }
    }
}
