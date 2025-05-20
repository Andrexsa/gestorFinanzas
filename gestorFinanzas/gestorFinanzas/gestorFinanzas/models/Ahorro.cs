namespace gestorFinanzas.models
{
    public class Ahorro
    {
        public int Id {get; set; }
        public string NombreAhorro { get; set; }
        public string TipoAhorro { get; set; } 
        public decimal TotalAhorro { get; set; }
        public decimal MontoObjetivo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinAhorro { get; set; }
        public string Frecuencia { get; set; } 
        public DateTime UltimaFechaIngreso { get; set; }


        public Ahorro(int id, string nombreAhorro, string tipoAhorro, decimal totalAhorro, decimal montoObjetivo, DateTime fechaInicio, DateTime fechaFinAhorro, string frecuencia, DateTime ultimaFechaIngreso)
        {
            Id = id;
            NombreAhorro = nombreAhorro;
            TipoAhorro = tipoAhorro;
            TotalAhorro = totalAhorro;
            MontoObjetivo = montoObjetivo;
            FechaInicio = DateTime.Now;
            FechaFinAhorro = DateTime.Now;
            Frecuencia = frecuencia;
            UltimaFechaIngreso = DateTime.Now;
        }
    }
}
