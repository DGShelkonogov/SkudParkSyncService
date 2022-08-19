using SkudParkSyncService.Models;
using SkudParkSyncService.Services;
using System.Collections.Generic;
using System.Windows.Controls;

namespace SkudParkSyncService.Pages
{
    public partial class ConfigSkudParkSyncServicePage : Page
    {
        public ConfigSkudParkSyncServicePage()
        {
            InitializeComponent();

            List<string> l = new List<string>
            {
                "11",
                "12",
                "13",
                "14",
                "15",
                "16",
                "17",
                "18"
            };

            updateList();
        }

        public async void updateList()
        {
            var listItems = await MSSQLConnection.getParking();
            ListBoxParkingRack.ItemsSource = listItems;
        }
    }
}
