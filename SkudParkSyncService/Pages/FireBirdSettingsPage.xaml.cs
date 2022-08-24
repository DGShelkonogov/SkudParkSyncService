using FirebirdSql.Data.FirebirdClient;
using Microsoft.Win32;
using Newtonsoft.Json;
using SkudParkSyncService.Models;
using SkudParkSyncService.Services;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SkudParkSyncService.Pages
{


    public partial class FireBirdSettingsPage : Page
    {
        private ObservableCollection<ServerType> _serverTypes = new ObservableCollection<ServerType>()
        {
            ServerType.LOCAL,
            ServerType.REMOTE
        };


        public FireBirdSettingsPage()
        {
            InitializeComponent();

            cmbServerType.ItemsSource = _serverTypes;
            txtPort.Text = "3050";

            FillFields();
        }

        private void ButtonClickOpenFile(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "База данных (*.gdb)|*.gdb";
            if (openFileDialog.ShowDialog() == true)
                txtPath.Text = openFileDialog.FileName;
        }

        private async void ButtonClickCheckConnection(object sender, RoutedEventArgs e)
        {
            var window = (MainWindow)Window.GetWindow(this);
            try
            {
                var connectionStringBuilder = new FbConnectionStringBuilder
                {
                    UserID = txtUsername.Text,
                    Password = txtPassword.Password,
                    Database = txtPath.Text,
                    DataSource = txtAddress.Text,
                    Port = Int32.Parse(txtPort.Text),
                    ServerType = 0
                };

                await Task.Run(() => {
                    var connection = new FbConnection(connectionStringBuilder.ToString());
                    connection.Open();
                    connection.Close();
                });

               
                window.EditFireBirdConnectionStatus(DBConnectionStatus.OPEN);

                txtMessageLog.Text = "Подключение прошло успешно";
                txtMessageLog.Foreground = Brushes.Green;
            }
            catch (Exception ex)
            {
                window.EditFireBirdConnectionStatus(DBConnectionStatus.MISSING);
                txtMessageLog.Text = ex.Message;
                txtMessageLog.Foreground = Brushes.Red;
            }
        }

        private async void ButtonClickAccept(object sender, RoutedEventArgs e)
        {
            var connectionStringBuilder = new FbConnectionStringBuilder
            {
                UserID = txtUsername.Text,
                Password = txtPassword.Password,
                Database = txtPath.Text,
                DataSource = txtAddress.Text,
                Port = Int32.Parse(txtPort.Text),
                ServerType = 0
            };

            var result = JsonConvert.SerializeObject(connectionStringBuilder);
            await FireBirdConnections.SaveConnectionString(result);
            var window = (MainWindow)Window.GetWindow(this);
            await window.CheckFireBirdConnectionStatus();
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
                    string connectionString = jsonObj["WorkerOptions"]["SkudDbConnectionString"];
                    var result = JsonConvert.DeserializeObject<FbConnectionStringBuilder>(connectionString);

                    txtUsername.Text = result.UserID;
                    txtPassword.Password = result.Password;
                    txtPath.Text = result.Database;
                    txtAddress.Text = result.DataSource;
                    txtPort.Text = result.Port.ToString();

                    if (txtAddress.Text != "localhost" && txtAddress.Text != "127.0.0.1")
                        cmbServerType.SelectedItem = ServerType.REMOTE;
                }
            }
            catch (Exception e)
            {

            }
        }
    }
}
