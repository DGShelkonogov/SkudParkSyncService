using SkudParkSyncService.Models;
using SkudParkSyncService.Services;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace SkudParkSyncService
{
    public partial class MainWindow : Window
    {
        public static string PathToAppsettings = "appsettings.json";

        public MainWindow()
        {
            InitializeComponent();
            CheckConnectionStatus();

            if (!File.Exists(PathToAppsettings))
            {
                string output = "{ \"WorkerOptions\": { " +
                    "\"SyncTimerMs\": 5000, " +
                    "\"SkudDbConnectionString\": \"\", " +
                    "\"ParkDbConnectionString\": \"\", " +
                    "\"retainedFileCountLimit\": 14, " +
                    "\"LogFolerPath\": \"C:\\\\ProgramData\\\\SkudParkSyncService\\\\\", " +
                    "\"sqlExpression\": \"select cd.id_cardindev, cd.id_card, cd.id_dev, cd.id_pep, cd.operation, cd.id_cardtype, p.surname, " +
                    "p.name, p.patronymic, cd.attempts from cardindev cd left join people p on cd.id_pep = p.id_pep where cd.id_cardtype = 4 " +
                    "order by cd.id_cardindev \", \"DeviceIdDictionary\": { }, \"DeactivateOnDelete\": false }, " +
                    "\"Logging\": { \"LogLevel\": { \"Default\": \"Trace\", " +
                    "\"System\": \"Information\", " +
                    "\"Microsoft\": \"None\", \"Microsoft.Hosting.Lifetime\": \"Warning\" } } } ";

                FileInfo fi = new FileInfo(PathToAppsettings);
                using (StreamWriter sw = fi.CreateText())
                {
                    sw.WriteLine(output);
                }
            }
        }

        public async void CheckConnectionStatus()
        {
            var status = await FireBirdConnections.CheckConnection();

            switch (status)
            {
                case DBConnectionStatus.OPEN:
                    {
                        ellipseDatabaseFireBirdStatus.Fill = Brushes.Green;
                        txtDatabaseFireBirdStatus.Text = "Подключение к базе данных настроено (Firebird)";
                        break;
                    }
                case DBConnectionStatus.MISSING:
                    {
                        ellipseDatabaseFireBirdStatus.Fill = Brushes.Red;
                        txtDatabaseFireBirdStatus.Text = "Подключение к базе данных отсутствует (Firebird)";
                        break;
                    }

                case DBConnectionStatus.NOT_CONFIGURATED:
                    {
                        ellipseDatabaseFireBirdStatus.Fill = Brushes.Orange;
                        txtDatabaseFireBirdStatus.Text = "Подключение к базе данных не настроено (Firebird)";
                        break;
                    }
            }
        }
    }
}
