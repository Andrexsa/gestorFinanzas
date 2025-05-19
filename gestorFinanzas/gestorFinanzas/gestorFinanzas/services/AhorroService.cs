    using System;
    using System.Collections.Generic;
    using System.Linq;
    using gestorFinanzas.models;
    using System.Data.SqlClient;
    using MySql.Data.MySqlClient;

    namespace gestorFinanzas.services
    {
    public class AhorroService
    {

        private static string _connectionString = "server=localhost;user=root; database=gestorfinanzas;password=;port=3306;";
        public void AgregarAhorro(Ahorro ahorro)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"
                INSERT INTO ahorro (
                    id_ahorro,
                    total_ahorrado,
                    fecha_ahorrado,
                    fecha_final_ahorrado,
                    tipo_ahorro,
                    fecha_inicio,
                    frecuencia,
                    nombre_ahorro
                ) VALUES (
                    @Id,
                    @TotalAhorro,
                    @UltimaFechaIngreso,
                    @FechaFinAhorro,
                    @TipoAhorro,
                    @FechaInicio,
                    @Frecuencia,
                    @NombreAhorro
                );";



                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", ahorro.Id);
                    cmd.Parameters.AddWithValue("@TotalAhorro", ahorro.TotalAhorro);
                    cmd.Parameters.AddWithValue("@UltimaFechaIngreso", ahorro.UltimaFechaIngreso);
                    cmd.Parameters.AddWithValue("@FechaFinAhorro", ahorro.FechaFinAhorro);
                    cmd.Parameters.AddWithValue("@TipoAhorro", ahorro.TipoAhorro);
                    cmd.Parameters.AddWithValue("@FechaInicio", ahorro.FechaInicio);
                    cmd.Parameters.AddWithValue("@Frecuencia", ahorro.Frecuencia);
                    cmd.Parameters.AddWithValue("@NombreAhorro", ahorro.NombreAhorro);


                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Ahorro> ObtenerAhorros()
        {
            List<Ahorro> ahorros = new List<Ahorro>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM ahorro";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var ahorro = new Ahorro(
                                reader.GetInt32(0), // Id
                                reader.GetString(1), //Nombre
                                reader.GetString(2), // Tipo
                                reader.GetDecimal(3), // TotalAhorro
                                reader.GetDateTime(4), // FechaInicio
                                reader.GetDateTime(5), // FechaFin
                                reader.GetString(6), // Frecuencia
                                reader.GetDateTime(7) // UltimaFechaIngreso
                            );

                            ahorros.Add(ahorro);
                        }
                    }
                }
            }

            return ahorros;
        }

        public void IngresarMonto(string nombreAhorro, decimal monto)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "UPDATE ahorro SET total_ahorrado = total_ahorrado + @Monto, fecha_ahorrado = @UltimaFechaIngreso WHERE nombre_ahorro = @NombreAhorro";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Monto", monto);
                    cmd.Parameters.AddWithValue("@UltimaFechaIngreso", DateTime.Now);
                    cmd.Parameters.AddWithValue("@NombreAhorro", nombreAhorro);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public Ahorro BuscarPorNombre(string nombreAhorro)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM ahorro WHERE LOWER(nombre_ahorro) = @NombreAhorro";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@NombreAhorro", nombreAhorro.ToLower());

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Ahorro(
                                reader.GetInt32("id_ahorro"),
                                reader.GetString("nombre_ahorro"),
                                reader.GetString("tipo_ahorro"),
                                reader.GetDecimal("total_ahorrado"),
                                reader.GetDateTime("fecha_inicio"),
                                reader.GetDateTime("fecha_final_ahorrado"),
                                reader.GetString("frecuencia"),
                                reader.GetDateTime("fecha_ahorrado")
                            );
                        }
                    }
                }
            }

            return null;
        }


    }
}