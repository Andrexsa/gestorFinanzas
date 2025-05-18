using System;
using System.ComponentModel;

namespace AppFinanciera.Models
{
    public class Inversion : INotifyPropertyChanged
    {
        private decimal _precioActual;
        private Activo _activo;

        public int IdInversion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public DateTime Tiempo { get; set; }
        public int IdActivo { get; set; }

        public Activo Activo
        {
            get => _activo;
            set
            {
                _activo = value;
                OnPropertyChanged(nameof(Activo));
            }
        }

        public decimal PrecioActual
        {
            get => _precioActual;
            set
            {
                _precioActual = value;
                OnPropertyChanged(nameof(PrecioActual));
                OnPropertyChanged(nameof(ValorActual));
                OnPropertyChanged(nameof(Ganancia));
            }
        }

        public decimal ValorActual => Cantidad * PrecioActual;
        public decimal Ganancia => ValorActual - (Cantidad * Precio);

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}