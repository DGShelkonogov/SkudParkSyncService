using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows;

namespace SkudParkSyncService.Services
{
    public class MSSQLConnection
    {
        public static async Task testConnections()
        {
            string connectionString = "Data Source=172.19.1.150;Initial Catalog=KalibrParking;User Id=sa;Password=Savin123;Persist Security Info=true;MultipleActiveResultSets=true";

            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.Clear();
            stringBuilder.DataSource = "172.19.1.150";
            stringBuilder.InitialCatalog = "KalibrParking";
            stringBuilder.UserID = "sa";
            stringBuilder.Password = "Savin123";
            stringBuilder.PersistSecurityInfo = true;
            stringBuilder.MultipleActiveResultSets = true;


            // Создание подключения
            SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
            try
            {
                // Открываем подключение
                await connection.OpenAsync();
                MessageBox.Show("Подключение открыто");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // если подключение открыто
                if (connection.State == ConnectionState.Open)
                {
                    // закрываем подключение
                    connection.Close();
                    MessageBox.Show("Подключение закрыто...");
                }
            }
        }
    }
}
