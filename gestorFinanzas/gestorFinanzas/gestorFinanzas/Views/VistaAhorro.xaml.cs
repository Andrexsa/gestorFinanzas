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
using gestorFinanzas.services;


namespace gestorFinanzas.views
{
    public partial class Ahorro : Window
    {
        private AhorroService _service = new AhorroService();

        public Ahorro()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtBuscarNombre.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Por favor ingresa el nombre del ahorro primero.");
                return;
            }


            IngresarDinero ingresarDinero = new IngresarDinero(this, nombre);
            ingresarDinero.Show();
            this.IsEnabled = false;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AgregarAhorro agregarAhorro = new AgregarAhorro();
            agregarAhorro.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
            this.Close();
        }

        private void txtBuscarAhorro_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "Ingrese nombre del ahorro...")
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }

        private void txtBuscarAhorro_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Ingrese nombre del ahorro...";
                textBox.Foreground = Brushes.Gray;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscarNombre.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Por favor ingrese un nombre de ahorro.");
                return;
            }

            AhorroController controller = new AhorroController();
            var ahorroEncontrado = controller.BuscarPorNombre(nombre);

            if (ahorroEncontrado != null)
            {
                MessageBox.Show($"✅ Ahorro encontrado:\n\nNombre: {ahorroEncontrado.NombreAhorro}\nTotal: {ahorroEncontrado.TotalAhorro:C}");
                ActualizarInterfazConAhorro(ahorroEncontrado);
            }
            else
            {
                MessageBox.Show("❌ Ahorro no encontrado.");
          
            }
        }




        public void ActualizarInterfazConAhorro(models.Ahorro ahorro, decimal montoIngresado = 0)
        {
            lblTotalAhorro.Text = $"${ahorro.TotalAhorro}";

            decimal meta = 5000;

            decimal restante = meta - ahorro.TotalAhorro;
            lblRestante.Text = $"Dinero restante: ${restante:N2}";


            int diasParaIngresar = CalcularDiasRestantes(ahorro);
            lblDiasRestantes.Text = $"Faltan {diasParaIngresar} días para volver a ingresar dinero al ahorro";
        }



        private int CalcularDiasRestantes(models.Ahorro ahorro)
        {
            int diasFrecuencia = ahorro.Frecuencia switch
            {
                "Diariamente" => 1,
                "Semanalmente" => 7,
                "Quincenalmente" => 15,
                "Mensualmente" => 30,
                _ => 7 // Valor por defecto
            };

            DateTime proximaFecha = ahorro.UltimaFechaIngreso.AddDays(diasFrecuencia);
            int diasRestantes = (proximaFecha.Date - DateTime.Today).Days;

            return diasRestantes > 0 ? diasRestantes : 0;
        }

    }
}

