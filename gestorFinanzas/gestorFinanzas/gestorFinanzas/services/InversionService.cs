using AppFinanciera.Models;
using AppFinanciera.DB;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace AppFinanciera.Services
{
    public class InversionService
    {
        public int ObtenerOInsertarActivo(string nombreActivo)
        {
            using (var connection = ConexionDB.GetOpenConnection())
            {
                string query = "SELECT id_activo FROM activos WHERE nombre = @nombre LIMIT 1";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombreActivo);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                }

                query = "INSERT INTO activos (nombre) VALUES (@nombre); SELECT LAST_INSERT_ID();";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombreActivo);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void GuardarInversion(Inversion inversion)
        {
            inversion.IdActivo = ObtenerOInsertarActivo(inversion.Activo?.Nombre ?? "Nuevo Activo");

            using (var connection = ConexionDB.GetOpenConnection())
            {
                string query = @"INSERT INTO inversiones (cantidad, precio, tiempo, id_activo)
                               VALUES (@cantidad, @precio, @tiempo, @id_activo);
                               SELECT LAST_INSERT_ID();";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@cantidad", inversion.Cantidad);
                    cmd.Parameters.AddWithValue("@precio", inversion.Precio);
                    cmd.Parameters.AddWithValue("@tiempo", inversion.Tiempo);
                    cmd.Parameters.AddWithValue("@id_activo", inversion.IdActivo);

                    inversion.IdInversion = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public List<Inversion> ObtenerInversionesPorActivo(int idActivo, decimal precioActual)
        {
            var inversiones = new List<Inversion>();

            using (var connection = ConexionDB.GetOpenConnection())
            {
                string query = @"SELECT i.id_inversion, i.cantidad, i.precio, i.tiempo, 
                               i.id_activo, a.nombre as Nombre
                        FROM inversiones i
                        JOIN activos a ON a.id_activo = i.id_activo
                        WHERE i.id_activo = @idActivo";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@idActivo", idActivo);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var inversion = new Inversion
                            {
                                IdInversion = reader.GetInt32("id_inversion"),
                                Cantidad = reader.GetDecimal("cantidad"),
                                Precio = reader.GetDecimal("precio"),
                                Tiempo = reader.GetDateTime("tiempo"),
                                IdActivo = reader.GetInt32("id_activo"),
                                Activo = new Activo
                                {
                                    IdActivo = reader.GetInt32("id_activo"),
                                    Nombre = reader.GetString("Nombre")
                                },
                                PrecioActual = precioActual
                            };

                            inversiones.Add(inversion);
                        }
                    }
                }
            }

            return inversiones;
        }





        public Inversion ObtenerInversionPorId(int idInversion, decimal precioActual)
        {
            using (var connection = ConexionDB.GetOpenConnection())
            {
                string query = @"SELECT i.id_inversion, i.cantidad, i.precio, i.tiempo, 
                                       i.id_activo, a.nombre as nombre
                                FROM inversiones i
                                JOIN activos a ON a.id_activo = i.id_activo
                                WHERE i.id_inversion = @idInversion";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@idInversion", idInversion);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Inversion
                            {
                                IdInversion = reader.GetInt32("id_inversion"),
                                Cantidad = reader.GetDecimal("cantidad"),
                                Precio = reader.GetDecimal("precio"),
                                Tiempo = reader.GetDateTime("tiempo"),
                                IdActivo = reader.GetInt32("id_activo"),
                                Activo = new Activo
                                {
                                    IdActivo = reader.GetInt32("id_activo"),
                                    Nombre = reader.GetString("nombre")
                                },
                                PrecioActual = precioActual
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void EliminarInversion(int idInversion)
        {
            using (var connection = ConexionDB.GetOpenConnection())
            {
                string query = "DELETE FROM inversiones WHERE id_inversion = @idInversion";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@idInversion", idInversion);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}