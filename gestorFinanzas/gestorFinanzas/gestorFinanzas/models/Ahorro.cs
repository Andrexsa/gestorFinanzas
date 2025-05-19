namespace gestorFinanzas.models
{
    public class Ahorro
    {
        public int Id {get; set; }
        public string NombreAhorro { get; set; }
        public string TipoAhorro { get; set; } // Casa, vehículo, etc.
        public decimal TotalAhorro { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinAhorro { get; set; }
        public string Frecuencia { get; set; } // Diario, Semanal, Mensual
        public DateTime UltimaFechaIngreso { get; set; }

        public Ahorro(int id, string nombreAhorro, string tipoAhorro, decimal totalAhorro, DateTime fechaInicio, DateTime fechaFinAhorro, string frecuencia, DateTime ultimaFechaIngreso)
        {
            Id = id;
            NombreAhorro = nombreAhorro;
            TipoAhorro = tipoAhorro;
            TotalAhorro = totalAhorro;
            FechaInicio = DateTime.Now;
            FechaFinAhorro = DateTime.Now;
            Frecuencia = frecuencia;
            UltimaFechaIngreso = DateTime.Now;
        }
    }
}
