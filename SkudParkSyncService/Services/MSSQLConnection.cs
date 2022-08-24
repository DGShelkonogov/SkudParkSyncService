using Newtonsoft.Json;
using SkudParkSyncService.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SkudParkSyncService.Services
{
    public class MSSQLConnection
    {
        public static SqlConnection GetConnection()
        {
            if (File.Exists(MainWindow.PathToAppsettings))
            {
                try
                {
                    string json = File.ReadAllText(MainWindow.PathToAppsettings);
                    dynamic jsonObj = JsonConvert.DeserializeObject(json);
                    string connectionString = jsonObj["WorkerOptions"]["ParkDbConnectionString"];
                    var result = JsonConvert.DeserializeObject<SqlConnectionStringBuilder>(connectionString);

                    var connection = new SqlConnection(result.ConnectionString);
                    connection.Open();
                    connection.Close();
                    return connection;
                }
                catch (Exception e)
                {

                }
            }
            return null;
        }

        public static async Task SaveConnectionString(string connectionStringJson)
        {
            await Task.Run(() => {
                string json = File.ReadAllText(MainWindow.PathToAppsettings);
                dynamic jsonObj = JsonConvert.DeserializeObject(json);
                jsonObj["WorkerOptions"]["ParkDbConnectionString"] = connectionStringJson;
                string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                File.WriteAllText(MainWindow.PathToAppsettings, output);
            });
        }

        public async static Task<DBConnectionStatus> CheckConnection()
        {
            if (!File.Exists(MainWindow.PathToAppsettings))
                return DBConnectionStatus.NOT_CONFIGURATED;

            string json = File.ReadAllText(MainWindow.PathToAppsettings);
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            string connectionString = jsonObj["WorkerOptions"]["ParkDbConnectionString"];

            if (connectionString.ToString().Length == 0)
                return DBConnectionStatus.NOT_CONFIGURATED;

            try
            {
                await Task.Run(() => {
                    var result = JsonConvert.DeserializeObject<SqlConnectionStringBuilder>(connectionString);
                    var connection = new SqlConnection(result.ConnectionString);
                    connection.Open();
                    connection.Close();
                });
            }
            catch (Exception e)
            {
                return DBConnectionStatus.MISSING;
            }

            return DBConnectionStatus.OPEN;
        }

        public static ObservableCollection<ListItem> GetParking(List<PassagePoint> passagePoints)
        {
            var list = new ObservableCollection<ListItem>();
            var connection = GetConnection();
            if(connection != null)
            {
                try
                {
                    connection.OpenAsync();
                    var cmd = new SqlCommand("select * from Gates", connection);

                    string json = File.ReadAllText(MainWindow.PathToAppsettings);
                    dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                    var DeviceIdDictionary = jsonObj["WorkerOptions"]["DeviceIdDictionary"];

                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string id = reader.GetInt32(0).ToString();
                                string name = reader.GetString(1);

                                var obj = DeviceIdDictionary.GetValue(id);

                                var point = (obj != null) ? 
                                    passagePoints.FirstOrDefault(x => x.Id == obj.Value) : null;

                                list.Add(new ListItem
                                {
                                    Id = id,
                                    Title = name,
                                    Items = new List<PassagePoint>(passagePoints),
                                    PassagePoint = point
                                });
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    
                }
                connection.Close();
            }
            return list;
        }
    }
}
