using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorFinanzas.models
{
    public class AreaInversion
    {
        public string Descripcion { get; set; }
        public decimal Valor { get; set; }

        public AreaInversion(string descripcion, decimal valor)
        {
            Descripcion = descripcion;
            Valor = valor;
        }
    }
}
