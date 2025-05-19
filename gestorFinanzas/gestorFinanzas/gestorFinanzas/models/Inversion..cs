using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorFinanzas.models
{
    public class Inversion
    {
        public string FechaInvertir { get; set; }
        public decimal Monto { get; set; }
        public string AreaInversion { get; set; }
        public string Moneda { get; set; }

        public Inversion(string fechaInvertir, decimal monto, string areaInversion, string moneda)
        {
            FechaInvertir = fechaInvertir;
            Monto = monto;
            AreaInversion = areaInversion;
            Moneda = moneda;
        }
    }
}
