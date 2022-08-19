using SkudParkSyncService.Models;
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

            List<ListItem> listItems = new List<ListItem>
            {
                new ListItem()
                {
                    Title = "1",
                    Items = l
                },
                new ListItem()
                {
                    Title = "2",
                    Items = l
                },
                new ListItem()
                {
                    Title = "3",
                    Items = l
                }
            };

            ListBoxParkingRack.ItemsSource = listItems;
        }
    }
}
