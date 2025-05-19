using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace gestorFinanzas.BD
{
    public class ConexionDB
    {
        private static string _connectionString = "server=localhost;user=root; database=gestorfinanzas;password=;port=3306;";

        public static MySqlConnection GetOpenConnection()
        {
            var connection = new MySqlConnection(_connectionString);
            try
            {
                connection.Open();
                return connection;
            }
            catch (MySqlException ex)
            {
                // Log error
                throw new Exception("Error al conectar con la base de datos", ex);
            }
        }

        public static bool TestConnection()
        {
            try
            {
                using (var connection = GetOpenConnection())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
