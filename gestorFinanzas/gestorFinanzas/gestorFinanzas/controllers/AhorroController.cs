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

        public void CrearAhorro(string tipo, decimal total, string fechaInicio, string fechaFin, string frecuencia)
        {
            var nuevoAhorro = new Ahorro(GenerarId(), tipo, total, fechaInicio, fechaFin, frecuencia);
            _servicio.AgregarAhorro(nuevoAhorro);
        }

        public void IngresarDinero(int id, decimal monto)
        {
            _servicio.IngresarMonto(id, monto);
        }

        public void MostrarAlerta(int id)
        {
            string mensaje = _servicio.VerificarRetraso(id);
            MessageBox.Show(mensaje, "Alerta de Ahorro");
        }

        public List<Ahorro> ObtenerTodos()
        {
            return _servicio.ObtenerAhorros();
        }

        private int GenerarId()
        {
            return new Random().Next(1000, 9999);
        }
    }
}
