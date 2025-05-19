using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestorFinanzas.models;
using gestorFinanzas.services;

namespace gestorFinanzas.controllers
{
    public class ConversorController
    {
        ConversorService servicioConversor;

        public ConversorController()
        {
            this.servicioConversor = new ConversorService();
        }

        public Conversor? obtenerConversion(string monedaBase, string monedaDestino, double monto)
        {
            return ConversorService.convertirMoneda(monedaBase, monedaDestino, monto);
        }
    }
}
