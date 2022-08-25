using SkudParkSyncService.Models;
using SkudParkSyncService.Services;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SkudParkSyncService.Pages
{
    public partial class ConfigSkudParkSyncServicePage : Page
    {
        private ObservableCollection<ListItem> _listItems = new ObservableCollection<ListItem>();

        public ConfigSkudParkSyncServicePage()
        {
            InitializeComponent();
            UpdateList();
        }

        public async void UpdateList()
        {
            await Task.Run(() => {
                var points = FireBirdConnections.GetPassagePoints();
                _listItems = MSSQLConnection.GetParking(points);
            });
            ListBoxParkingRack.ItemsSource = _listItems;
        }

        private void ComboBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var cmb = sender as ComboBox;
                cmb.IsDropDownOpen = true;
                var tb = e.OriginalSource as TextBox;

                tb.Select(tb.SelectionStart + tb.SelectionLength, 0);

                var cv = (CollectionView)CollectionViewSource.GetDefaultView(cmb.ItemsSource);
                cv.Filter = s =>
                    ((s as PassagePoint).Title).IndexOf(cmb.Text,
                    StringComparison.CurrentCultureIgnoreCase) >= 0;
            }
            catch(Exception ex)
            {

            }
        }

        private void ButtonClickUpdate(object sender, RoutedEventArgs e)
        {
            UpdateList();
        }

        private void ButtonClickSave(object sender, RoutedEventArgs e)
        {
            foreach (ListItem item in ListBoxParkingRack.ItemsSource)
            {
                if(item.PassagePoint != null)
                    AddDevice(item.Id, item.PassagePoint.Id);
                else
                    RemoveDevice(item.Id);
            }
        }

        public void AddDevice(string idDev, string idPoint)
        {
            try
            {
                string json = File.ReadAllText(MainWindow.PathToAppsettings);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                jsonObj["WorkerOptions"]["DeviceIdDictionary"].Add(idDev, idPoint);
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(MainWindow.PathToAppsettings, output);
            }
            catch (Exception e)
            {

            }
        }

        public void RemoveDevice(string idDev)
        {
            try
            {
                string json = File.ReadAllText(MainWindow.PathToAppsettings);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                jsonObj["WorkerOptions"]["DeviceIdDictionary"].Remove(idDev);
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(MainWindow.PathToAppsettings, output);
            }
            catch (Exception e)
            {

            }
        }

        private void ButtonClickRemove(object sender, RoutedEventArgs e)
        {
            try
            {
                string id = ((sender as Button).DataContext as PassagePoint).Id;
                foreach (var item in _listItems)
                {
                    if (item?.PassagePoint?.Id == id)
                        item.PassagePoint = null;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Не получается удалить. Ошибка: " + ex.Message);
            }
        }
    }
}
