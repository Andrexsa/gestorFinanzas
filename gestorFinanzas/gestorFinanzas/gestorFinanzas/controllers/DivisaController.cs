using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestorFinanzas.models;

namespace gestorFinanzas.controllers
{
    public class DivisaController
    {
        Divisa? divisas;

        public DivisaController() {
            this.divisas = new Divisa();
        }

        public List<string> obtenerDivisas()
        {
            return divisas.getlistaMonedas();
        }
    }
}
