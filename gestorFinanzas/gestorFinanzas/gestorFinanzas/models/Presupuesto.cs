using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorFinanzas.models
{
    public class Presupuesto
    {
        public decimal MontoIngresar { get; set; }
        public string FechaIngresar { get; set; }
        public bool PermitirGastoTotal { get; set; }

        public Presupuesto(decimal montoIngresar, string fechaIngresar, bool permitirGastoTotal)
        {
            MontoIngresar = montoIngresar;
            FechaIngresar = fechaIngresar;
            PermitirGastoTotal = permitirGastoTotal;
        }
    }
}
