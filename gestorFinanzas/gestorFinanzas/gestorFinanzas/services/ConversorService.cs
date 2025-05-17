using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using gestorFinanzas.models;

namespace gestorFinanzas.services
{
    public class ConversorService
    {
        public static Conversor? convertirMoneda(string monedaBase, string monedaDestino, double monto)
        {
            Conversor? conversor = new Conversor();

            string url = $"https://v6.exchangerate-api.com/v6/04a67607a37a70cc5466f131/pair/{monedaBase}/{monedaDestino}/{monto}";

            try
            {
                using (HttpClient client = new HttpClient())
                {

                    HttpResponseMessage respuesta = client.GetAsync(url).GetAwaiter().GetResult();

                    respuesta.EnsureSuccessStatusCode();

                    string solicitud = respuesta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                    conversor = JsonSerializer.Deserialize<Conversor>(solicitud);

                    return conversor;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
    }
}
