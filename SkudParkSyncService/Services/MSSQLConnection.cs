using Newtonsoft.Json;
using SkudParkSyncService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

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


        public static async Task<List<ListItem>> getParking()
        {
            var list = new List<ListItem>();
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.Clear();
            stringBuilder.DataSource = "localhost";
            stringBuilder.InitialCatalog = "KalibrParking";
            stringBuilder.UserID = "kalibr";
            stringBuilder.Password = "Savin123Savin123";


            // Создание подключения
            SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);

            //connection = GetConnection();
            try
            {   
                // Открываем подключение
                await connection.OpenAsync();
                MessageBox.Show("Подключение открыто");
                SqlCommand cmd = new SqlCommand("select * from Gates", connection);

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            list.Add(new ListItem 
                            { 
                                Id = id, 
                                Title = name
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
            return list;
        }
    }
}
