using gestorFinanzas.models;

namespace gestorFinanzas.services
{
    public class AhorroService
    {
        private List<Ahorro> _listaAhorros = new List<Ahorro>();

        public void AgregarAhorro(Ahorro ahorro)
        {
            _listaAhorros.Add(ahorro);
        }

        public void IngresarMonto(int idAhorro, decimal monto)
        {
            var ahorro = _listaAhorros.FirstOrDefault(a => a.Id == idAhorro);
            if (ahorro == null)
            {
                ahorro.TotalAhorro += monto;
                ahorro.UltimaFechaIngreso = DateTime.Now;
            }
        }

        public string VerificarRetraso(int idAhorro)
        {
            var ahorro = _listaAhorros.FirstOrDefault(a => a.Id == idAhorro);
            if (ahorro == null) return "Ahorro no encontrado.";

            TimeSpan diferencia = DateTime.Now - ahorro.UltimaFechaIngreso;
            int diasPasados = diferencia.Days;

            int diasPermitidos = ahorro.Frecuencia switch
            {
                "Diario" => 1,
                "Semanal" => 7,
                "Mensual" => 30,
                _ => 0
            };

            if (diasPasados > diasPermitidos)
            {
                return $"¡Alerta! Te pasaste {diasPasados - diasPermitidos} día(s) desde el último ingreso.";
            }

            return "Estás al día con este ahorro.";
        }

        public List<Ahorro> ObtenerAhorros()
        {
            return _listaAhorros;
        }
    }
}
