using FirebirdSql.Data.FirebirdClient;
using Newtonsoft.Json;
using SkudParkSyncService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SkudParkSyncService.Services
{
    public class FireBirdConnections
    {
        public static FbConnection GetConnection()
        {
            if (File.Exists(MainWindow.PathToAppsettings))
            {
                try
                {
                    string json = File.ReadAllText(MainWindow.PathToAppsettings);
                    dynamic jsonObj = JsonConvert.DeserializeObject(json);
                    string connectionString = jsonObj["WorkerOptions"]["SkudDbConnectionString"];
                    var result = JsonConvert.DeserializeObject<FbConnectionStringBuilder>(connectionString);

                    var connection = new FbConnection(result.ToString());
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
            try
            {
                await Task.Run(() => {
                    string json = File.ReadAllText(MainWindow.PathToAppsettings);
                    dynamic jsonObj = JsonConvert.DeserializeObject(json);
                    jsonObj["WorkerOptions"]["SkudDbConnectionString"] = connectionStringJson;
                    string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                    File.WriteAllText(MainWindow.PathToAppsettings, output);
                });
            }
            catch(Exception e)
            {

            }
        }

        public async static Task<DBConnectionStatus> CheckConnection()
        {
            if (!File.Exists(MainWindow.PathToAppsettings))
                return DBConnectionStatus.NOT_CONFIGURATED;

            string json = File.ReadAllText(MainWindow.PathToAppsettings);
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            string connectionString = jsonObj["WorkerOptions"]["SkudDbConnectionString"];

            if (connectionString.ToString().Length == 0)
                return DBConnectionStatus.NOT_CONFIGURATED;

            try
            {
                await Task.Run(() => {
                    var result = JsonConvert.DeserializeObject<FbConnectionStringBuilder>(connectionString);
                    var connection = new FbConnection(result.ToString());
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

        public static List<PassagePoint> GetPassagePoints()
        {
            var list = new List<PassagePoint>();
            var connection = GetConnection();
            if (connection != null)
            {
                try
                {
                    connection.OpenAsync();
                    var command = 
                        new FbCommand("select cast(d.name as varchar(50) character set UTF8), d.id_dev from device d where d.id_reader is not null", 
                        connection);

                    using (FbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader[0].ToString();
                            string idDev = reader["ID_DEV"].ToString();
                            list.Add(new PassagePoint
                            {
                                Id = idDev,
                                Title = name
                            });

                        }
                    }
                }
                catch (Exception e)
                {
                    
                }
                connection.Close();
            }

            list.Sort((left, right) => left.Title.CompareTo(right.Title));

            return list;
        }
    }
}
