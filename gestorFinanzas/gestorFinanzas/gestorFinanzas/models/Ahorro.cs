namespace gestorFinanzas.models
{
    public class Ahorro
    {
        public int Id { get; set; }
        public string TipoAhorro { get; set; } // Casa, vehículo, etc.
        public decimal TotalAhorro { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFinAhorro { get; set; }
        public string Frecuencia { get; set; } // Diario, Semanal, Mensual
        public DateTime UltimaFechaIngreso { get; set; }

        public Ahorro(int id, string tipoAhorro, decimal totalAhorro, string fechaInicio, string fechaFinAhorro, string frecuencia)
        {
            Id = id;
            TipoAhorro = tipoAhorro;
            TotalAhorro = totalAhorro;
            FechaInicio = fechaInicio;
            FechaFinAhorro = fechaFinAhorro;
            Frecuencia = frecuencia;
            UltimaFechaIngreso = DateTime.Now;
        }
    }
}
