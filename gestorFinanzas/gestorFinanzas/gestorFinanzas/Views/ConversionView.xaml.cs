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
    }
}
