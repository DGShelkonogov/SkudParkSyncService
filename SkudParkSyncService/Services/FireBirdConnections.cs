using FirebirdSql.Data.FirebirdClient;
using Newtonsoft.Json;
using System;
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
            await Task.Run(() => {
                string json = File.ReadAllText(MainWindow.PathToAppsettings);
                dynamic jsonObj = JsonConvert.DeserializeObject(json);
                jsonObj["WorkerOptions"]["SkudDbConnectionString"] = connectionStringJson;
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
    }
}
