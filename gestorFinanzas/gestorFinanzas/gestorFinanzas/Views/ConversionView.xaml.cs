using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using gestorFinanzas.controllers;
using gestorFinanzas.models;
using LiveCharts;
using LiveCharts.Wpf;

namespace gestorFinanzas.Views
{
    /// <summary>
    /// Lógica de interacción para ConversionView.xaml
    /// </summary>
    public partial class ConversionView : Window
    {
        ConversorController controladorConversor;
        DivisaController divisaControlador;
        public ConversionView()
        {
            InitializeComponent();
            controladorConversor = new ConversorController();
            divisaControlador = new DivisaController();
            CargarListas();
            SeriesCollection = new SeriesCollection
            {
                new RowSeries
                {
                    Title = "Ventas 2015",
                    Values = new ChartValues<double>{10, 50, 39, 58, 45, 25}
                }
            };

            SeriesCollection.Add(new RowSeries
            {
                Title = "Ventas 2016",
                Values = new ChartValues<double> { 11, 56, 46, 48, 23, 35}
            });

            Labels = GenerarFechas();
            Formatter = value => value.ToString();
            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double,string> Formatter { get; set; }

        public void CargarListas()
        {
            List<string> listadoDivisas = divisaControlador.obtenerDivisas();
            divisaOrigenSeleccion.ItemsSource = listadoDivisas;
            divisaDestinoSeleccion.ItemsSource= listadoDivisas;
        }

        private void botonConvertir_Click(object sender, RoutedEventArgs e)
        {
            String divisaOriginal = divisaOrigenSeleccion.Text;
            String divisaObjetivo = divisaDestinoSeleccion.Text;
            int cantidad = int.Parse(monto.Text); 
            Conversor? conversion = controladorConversor.obtenerConversion(divisaOriginal, divisaObjetivo, cantidad);
            montoConvertido.Text = conversion?.conversion_result.ToString();
        }

        public string[] GenerarFechas()
        {
            string[] fechas = new string[6];
            int numerador = 1;
            DateTime Hoy = DateTime.Now;
            for (int i = 0; i < 6; i++)
            {
                DateTime FechaRestada = Hoy.AddDays(-numerador - i);
                fechas[i] = FechaRestada.ToString("dd/MM/yyyy");
            }
            return fechas;
        } 
    }
}
