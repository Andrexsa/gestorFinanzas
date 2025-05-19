using System;
using System.Windows;
using System.Windows.Input;
using gestorFinanzas.controllers;
using gestorFinanzas.models;

namespace gestorFinanzas.views
{
    public partial class IngresarDinero : Window
    {
        private AhorroController controller = new AhorroController();
        private Ahorro ventanaAhorro;
        private string nombreAhorro;

        public IngresarDinero(Ahorro ahorroWindow, string nombre)
        {
            InitializeComponent();
            ventanaAhorro = ahorroWindow;
            nombreAhorro = nombre;
        }

        private void txtCantidad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !decimal.TryParse(e.Text, out _);
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(txtCantidad.Text, out decimal monto) && monto > 0)
            {
                var ahorroActualizado = controller.IngresarDinero(nombreAhorro, monto);

                if (ahorroActualizado != null)
                {
                    MessageBox.Show("Dinero ingresado correctamente.");
                    ventanaAhorro.ActualizarInterfazConAhorro(ahorroActualizado);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el ahorro.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor ingresa una cantidad válida y mayor que cero.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
