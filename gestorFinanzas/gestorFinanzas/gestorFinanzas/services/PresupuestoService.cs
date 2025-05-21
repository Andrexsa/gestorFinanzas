using gestorFinanzas.BD;
using gestorFinanzas.models;
using MySql.Data.MySqlClient;

namespace gestorFinanzas.services
{
    public class PresupuestoService
    {
        public bool AgregarPresupuesto(Presupuesto presupuesto)
        {
            using (MySqlConnection connection = ConexionDB.GetOpenConnection())
            {
                string query = "INSERT INTO Presupuesto (NombreProducto, Precio) VALUES (@NombreProducto, @Precio)";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@NombreProducto", presupuesto.NombreProducto);
                command.Parameters.AddWithValue("@Precio", presupuesto.Precio);

                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool Actualizar(int id, string nombreProducto, decimal precio)
        {
            string query = "UPDATE Presupuesto SET NombreProducto = @nombre, Precio = @precio WHERE Id = @id";

            using (var conn = ConexionDB.GetOpenConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nombre", nombreProducto);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@id", id);

                return cmd.ExecuteNonQuery() > 0;
            }
        }



        public List<Presupuesto> ListarPresupuestos()
        {
            List<Presupuesto> lista = new List<Presupuesto>();

            using (MySqlConnection connection = ConexionDB.GetOpenConnection())
            {
                string query = "SELECT Id, NombreProducto, Precio FROM Presupuesto";
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Presupuesto p = new Presupuesto
                        {
                            Id = reader.GetInt32("Id"),
                            NombreProducto = reader.GetString("NombreProducto"),
                            Precio = reader.GetDecimal("Precio")
                        };
                        lista.Add(p);
                    }
                }
            }

            return lista;
        }

        public bool EliminarPresupuestoPorId(int id)
        {
            using (MySqlConnection connection = ConexionDB.GetOpenConnection())
            {
                string query = "DELETE FROM Presupuesto WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }


        public decimal ObtenerTotalGastos()
        {
            using (MySqlConnection conn = ConexionDB.GetOpenConnection())
            {
                string query = "SELECT SUM(Precio) FROM Presupuesto";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
        }


    }
}
