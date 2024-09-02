using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace c969v2.Data
{
    public class DatabaseConnection
    {
        private string connectionString;

        public DatabaseConnection()
        {
            // Define your connection string here
            connectionString = "Server=localhost;Database=mydatabase;User ID=myusername;Password=mypassword;";
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        // Example method to test the connection
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