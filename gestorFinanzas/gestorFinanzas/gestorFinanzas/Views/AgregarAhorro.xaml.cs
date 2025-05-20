using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Globalization;
using System.Text.RegularExpressions;
using MySql.Data;
using gestorFinanzas.controllers;

namespace gestorFinanzas.views
{   
    /// <summary>
    /// Lógica de interacción para AgregarAhorro.xaml
    /// </summary>
    public partial class AgregarAhorro : Window
    {
        public AgregarAhorro()
        {
            InitializeComponent();
        }
        private void Button_Click_Cancelar(object sender, RoutedEventArgs e)
        {
            Principal principal = new Principal();
            principal.Show(); 

            principal.Show();
            this.Close();
        }
       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtNombreAhorro.Text) ||
                cmbTipoAhorro.SelectedItem == null ||
                cmbFrecuencia.SelectedItem == null ||
                cmbDuracion.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                MessageBox.Show("Complete todos los campos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string nombreAhorro = txtNombreAhorro.Text.Trim();
            string tipoAhorro = ((ComboBoxItem)cmbTipoAhorro.SelectedItem).Content.ToString();
            string frecuencia = ((ComboBoxItem)cmbFrecuencia.SelectedItem).Content.ToString();
            string duracion = ((ComboBoxItem)cmbDuracion.SelectedItem).Content.ToString();

            if (!decimal.TryParse(txtMonto.Text, out decimal monto))
            {
                MessageBox.Show("Monto inválido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DateTime fechaInicio = DateTime.Now;
            DateTime fechaFinAhorro;

            switch (duracion)
            {
                case "1 Semana":
                    fechaFinAhorro = fechaInicio.AddDays(7);
                    break;
                case "15 Días":
                    fechaFinAhorro = fechaInicio.AddDays(15);
                    break;
                case "1 Mes":
                    fechaFinAhorro = fechaInicio.AddMonths(1);
                    break;
                case "6 Meses":
                    fechaFinAhorro = fechaInicio.AddMonths(6);
                    break;
                case "1 Año":
                    fechaFinAhorro = fechaInicio.AddYears(1);
                    break;
                case "2 Años":
                    fechaFinAhorro = fechaInicio.AddYears(2);
                    break;
                default:
                    fechaFinAhorro = fechaInicio;
                    break;
            }

            try
            {
                _controller.CrearAhorro(
                    id: 0,
                    nombreAhorro: nombreAhorro,
                    tipoAhorro: tipoAhorro,
                    totalAhorro: 0, 
                    montoObjetivo: monto, 
                    fechaInicio: fechaInicio,
                    fechaFinAhorro: fechaFinAhorro,
                    frecuencia: frecuencia,
                    ultimaFechaIngreso: fechaInicio
                );


                MessageBox.Show("Ahorro guardado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                Ahorro ahorro = new Ahorro();
                ahorro.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar ahorro: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }



      
            this.Close();
        }

        private void txtMonto_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        private AhorroController _controller = new AhorroController();

    }
}
