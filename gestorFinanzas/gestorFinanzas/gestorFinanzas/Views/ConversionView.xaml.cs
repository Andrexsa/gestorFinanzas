using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using gestorFinanzas.views;
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
            if (string.IsNullOrWhiteSpace(monto.Text))
            {
                MessageBox.Show("El campo monto es obligatorio.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (divisaOrigenSeleccion.SelectedItem == null || divisaDestinoSeleccion.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una divisa en ambos campos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            String divisaOriginal = divisaOrigenSeleccion.Text;
            String divisaObjetivo = divisaDestinoSeleccion.Text;
            int cantidad = int.Parse(monto.Text); 
            Conversor? conversion = controladorConversor.obtenerConversion(divisaOriginal, divisaObjetivo, cantidad);
            string? total = conversion?.conversion_result.ToString();
            montoConvertido.Text = total;
            detalle.Text = cantidad.ToString() + divisaOriginal + " equivalen a " + total + divisaObjetivo;
            CargarGrafico(divisaOriginal, divisaObjetivo);
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



        public ChartValues<double> GenerarResultados()
        {
            ChartValues<double> coleccion = new ChartValues<double>();
            double trm = 0;
            double cantidad = double.Parse(monto.Text);
            Random random = new Random();
            for (int i = 0; i < 6; i++) {
                
                double tasa = random.NextDouble();
                trm = cantidad * tasa;
                coleccion.Add(trm);
            }
            return coleccion;
        }

        public void CargarGrafico(string divisaOriginal, string divisaDestino)
        {
            SeriesCollection = new SeriesCollection
            {
                new RowSeries
                {
                    Title = divisaDestino,
                    Values = GenerarResultados()
                }
            };

            /**SeriesCollection.Add(new RowSeries
            {
                Title = divisaOriginal,
                Values = new ChartValues<double> { 11, 56, 46, 48, 23, 35 }
            });**/

            Labels = GenerarFechas();
            Formatter = value => value.ToString();
            DataContext = null;
            DataContext = this;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
            principal.Show();
            this.Close();
        }
    }
}
