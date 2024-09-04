using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace c969v2.Data
{
    public class DatabaseConnection
    {
        private string connectionString;

        public DatabaseConnection()
        {
            connectionString = "Server=127.0.0.1;" +
                               "Port=3306;" +
                               "Database=client_schedule;" +
                               "Uid=sqlUser;" +
                               "Pwd=Passw0rd!;";
        }
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
        public bool TestConnection()
        {
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }
    }
}