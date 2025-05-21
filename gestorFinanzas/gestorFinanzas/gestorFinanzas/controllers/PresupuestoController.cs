using gestorFinanzas.models;
using gestorFinanzas.services;
using gestorFinanzas.models;


namespace gestorFinanzas.controllers
{
    public class PresupuestoController
    {
        private PresupuestoService presupuestoService;

        public PresupuestoController()
        {
            presupuestoService = new PresupuestoService();
        }

        public bool CrearPresupuesto(string nombreProducto, decimal precio)
        {
            Presupuesto presupuesto = new Presupuesto
            {
                NombreProducto = nombreProducto,
                Precio = precio
            };

            return presupuestoService.AgregarPresupuesto(presupuesto);
        }
        public List<Presupuesto> ListarPresupuestos()
        {
            return presupuestoService.ListarPresupuestos();
        }

        public bool EliminarPresupuestoPorId(int id)
        {
            return presupuestoService.EliminarPresupuestoPorId(id);
        }


        public bool ActualizarPresupuesto(int id, string nombreProducto, decimal precio)
        {
            // Suponiendo que usas algún ORM o clase conexión:
            try
            {
                // Reemplaza con tu lógica de base de datos
                return presupuestoService.Actualizar(id, nombreProducto, precio);
            }
            catch
            {
                return false;
            }
        }

    }
}

