using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorFinanzas.models
{
    public class Presupuesto
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }

        public Presupuesto() { }

        public Presupuesto(int id, string nombreProducto, decimal precio)
        {
            Id = id;
            NombreProducto = nombreProducto;
            Precio = precio;
        }
    }
}
