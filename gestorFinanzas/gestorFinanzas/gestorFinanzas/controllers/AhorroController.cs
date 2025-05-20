using gestorFinanzas.models;
using gestorFinanzas.services;
using System.Windows;

namespace gestorFinanzas.controllers
{
    public class AhorroController
    {
        private AhorroService _servicio;

        public AhorroController()
        {
            _servicio = new AhorroService();
        }

        public void CrearAhorro(int id, string nombreAhorro, string tipoAhorro, decimal totalAhorro, decimal montoObjetivo, DateTime fechaInicio, DateTime fechaFinAhorro, string frecuencia, DateTime ultimaFechaIngreso)
        {
            var nuevoAhorro = new Ahorro(GenerarId(), nombreAhorro, tipoAhorro, totalAhorro, montoObjetivo, fechaInicio, fechaFinAhorro, frecuencia, ultimaFechaIngreso);
            _servicio.AgregarAhorro(nuevoAhorro);
        }


       
        public models.Ahorro IngresarDinero(string nombreAhorro, decimal monto)
        {
            _servicio.IngresarMonto(nombreAhorro, monto);

            var ahorro = BuscarPorNombre(nombreAhorro);

            return ahorro;
        }

        public List<Ahorro> ObtenerTodos()
        {
            return _servicio.ObtenerAhorros();
        }

        private int GenerarId()
        {
            return new Random().Next(1000, 9999);
        }

        public Ahorro BuscarPorNombre(string nombreAhorro)
        {
            return _servicio.BuscarPorNombre(nombreAhorro);
        }
    }
}
