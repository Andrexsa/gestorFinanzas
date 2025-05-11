using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorFinanzas.models
{
    public class Moneda
    {
        public string Nombre { get; set; }
        public string PaisOrigen { get; set; }

        public Moneda(string nombre, string paisOrigen)
        {
            Nombre = nombre;
            PaisOrigen = paisOrigen;
        }
    }
}
