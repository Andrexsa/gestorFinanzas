using gestorFinanzas.controllers;
using gestorFinanzas.models;
using gestorFinanzas.services;
using gestorFinanzas.views;
using System.Windows;
using System.Windows.Controls;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using Microsoft.Win32;

using iText.Layout.Element;
using iText.Layout.Properties;
using System.IO;
using Paragraph = iText.Layout.Element.Paragraph;
using Table = iText.Layout.Element.Table;

namespace gestorFinanzas.Views
{
    public partial class PresupuestoView : Window
    {
        private PresupuestoController presupuestoController;
        private IngresoService ingresoService = new IngresoService();
        private PresupuestoService presupuestoService = new PresupuestoService();
        private Presupuesto presupuestoSeleccionado;

        private decimal ingresoManual = 0; // Ingreso ingresado manualmente por el usuario

        public PresupuestoView()
        {
            InitializeComponent();
            presupuestoController = new PresupuestoController();
            CargarPresupuestos();
        }

        private void CargarPresupuestos()
        {
            var lista = presupuestoController.ListarPresupuestos();
            DataGridPresupuestos.ItemsSource = null;
            DataGridPresupuestos.ItemsSource = lista;
            MostrarSaldo();
            CalcularTotales();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            string nombreProducto = txtDescripcionProducto.Text;

            if (decimal.TryParse(txtPrecioProducto.Text, out decimal precio))
            {
                bool resultado = presupuestoController.CrearPresupuesto(nombreProducto, precio);

                if (resultado)
                {
                    MessageBox.Show("Presupuesto guardado correctamente.");
                    LimpiarCampos();
                    CargarPresupuestos();
                    CalcularTotales();
                }
                else
                {
                    MessageBox.Show("Error al guardar el presupuesto.");
                }
            }
            else
            {
                MessageBox.Show("El precio ingresado no es válido.");
            }
        }

        private void btnLimpiarCampos_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtDescripcionProducto.Clear();
            txtPrecioProducto.Clear();
            DataGridPresupuestos.UnselectAll();
            presupuestoSeleccionado = null;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridPresupuestos.SelectedItem is Presupuesto presupuestoSeleccionado)
            {
                var resultado = MessageBox.Show(
                    $"¿Deseas eliminar el presupuesto '{presupuestoSeleccionado.NombreProducto}'?",
                    "Confirmar eliminación",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning
                );

                if (resultado == MessageBoxResult.Yes)
                {
                    bool eliminado = presupuestoController.EliminarPresupuestoPorId(presupuestoSeleccionado.Id);
                    if (eliminado)
                    {
                        MessageBox.Show("Presupuesto eliminado correctamente.");
                        LimpiarCampos();
                        CargarPresupuestos();
                        CalcularTotales();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el presupuesto.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un presupuesto en la tabla para eliminarlo.");
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
            this.Close();
        }

        private void DataGridPresupuestos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridPresupuestos.SelectedItem is Presupuesto seleccionado)
            {
                presupuestoSeleccionado = seleccionado;
                txtDescripcionProducto.Text = seleccionado.NombreProducto;
                txtPrecioProducto.Text = seleccionado.Precio.ToString();
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (presupuestoSeleccionado == null)
            {
                MessageBox.Show("Selecciona un presupuesto para editar.");
                return;
            }

            string nuevoNombre = txtDescripcionProducto.Text;

            if (decimal.TryParse(txtPrecioProducto.Text, out decimal nuevoPrecio))
            {
                bool actualizado = presupuestoController.ActualizarPresupuesto(presupuestoSeleccionado.Id, nuevoNombre, nuevoPrecio);

                if (actualizado)
                {
                    MessageBox.Show("Presupuesto actualizado correctamente.");
                    CargarPresupuestos();
                    LimpiarCampos();
                    CalcularTotales();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el presupuesto.");
                }
            }
            else
            {
                MessageBox.Show("El precio ingresado no es válido.");
            }
        }

        private void MostrarSaldo()
        {
            decimal totalIngresos = ingresoService.ObtenerTotalIngresos();
            decimal totalGastos = presupuestoService.ObtenerTotalGastos();
            decimal saldo = (totalIngresos + ingresoManual) - totalGastos;

            lblSaldo.Content = $"Saldo disponible: {saldo:C}";
        }

        private void btnAgregarIngreso_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(txtIngresoManual.Text, out decimal ingreso))
            {
                ingresoManual = ingreso;
                MostrarSaldo();
                MessageBox.Show("Ingreso agregado correctamente.");
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un valor válido.");
            }
        }

        private void CalcularTotales()
        {
            decimal total = 0;

            foreach (var item in DataGridPresupuestos.Items)
            {
                if (item is Presupuesto presupuesto)
                {
                    total += presupuesto.Precio;
                }
            }

            txtTotal.Text = $"$ {total:N0}";
            txtTotalConDescuento.Text = $"$ {total:N0}"; // Aquí puedes aplicar descuentos si deseas
        }



        private void GenerarPDF()
        {
            // Cuadro de diálogo para seleccionar ubicación y nombre del archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivos PDF (*.pdf)|*.pdf",
                FileName = "Presupuestos.pdf",
                Title = "Guardar como PDF"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string path = saveFileDialog.FileName;

                using (PdfWriter writer = new PdfWriter(path))
                using (PdfDocument pdf = new PdfDocument(writer))
                using (Document document = new Document(pdf))
                {
                    PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

                    document.Add(new Paragraph("Lista de Presupuestos")
                        .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                        .SetFontSize(20)
                        .SetFont(boldFont));

                    document.Add(new Paragraph("\n"));

                    Table table = new Table(3).UseAllAvailableWidth();
                    table.AddHeaderCell("ID");
                    table.AddHeaderCell("Descripción");
                    table.AddHeaderCell("Precio");

                    decimal total = 0;

                    foreach (var item in DataGridPresupuestos.Items)
                    {
                        if (item is Presupuesto presupuesto)
                        {
                            table.AddCell(presupuesto.Id.ToString());
                            table.AddCell(presupuesto.NombreProducto);
                            table.AddCell($"$ {presupuesto.Precio:N2}");
                            total += presupuesto.Precio;
                        }
                    }

                    document.Add(table);
                    document.Add(new Paragraph("\n"));

                    document.Add(new Paragraph($"Total: $ {total:N2}")
                        .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)
                        .SetFontSize(14)
                        .SetFont(boldFont));
                }

                MessageBox.Show("PDF generado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnGenerarPDF_Click(object sender, RoutedEventArgs e)
        {
            GenerarPDF();
        }


    }
}
