using gestorFinanzas.BD;
using gestorFinanzas.models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace gestorFinanzas.services
{
    public class IngresoService
    {
        public decimal ObtenerTotalIngresos()
        {
            decimal total = 0;

            using (var connection = ConexionDB.GetOpenConnection())
            {
                string query = "SELECT SUM(Monto) FROM Ingresos"; 

                using (var command = new MySqlCommand(query, connection))
                {
                    var result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                        total = Convert.ToDecimal(result);
                }
            }

            return total;
        }
    }
}
