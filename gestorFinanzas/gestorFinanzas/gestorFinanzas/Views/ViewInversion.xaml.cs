using gestorFinanzas.controllers;
using gestorFinanzas.Controllers;
using gestorFinanzas.models;
using gestorFinanzas.services;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WPF;
using SkiaSharp;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace gestorFinanzas.Views
{
    public partial class ViewInversion : Window, INotifyPropertyChanged
    {
        private readonly TradingService _tradingService = new();
        private readonly InversionController _inversionController = new();
        private readonly DispatcherTimer _timer;
        private CandlesticksSeries<CustomOhlcPoint> _candleSeries;
        private Axis _xAxis;
        private Axis _yAxis;
        private ObservableCollection<CustomOhlcPoint> _datos = new();
        private ObservableCollection<Inversion> _inversiones = new();
        private string _tipoActivo = "Acciones";
        private decimal _precioActual;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Inversion> Inversiones
        {
            get => _inversiones;
            set
            {
                _inversiones = value;
                OnPropertyChanged(nameof(Inversiones));
            }
        }

        public decimal PrecioActual
        {
            get => _precioActual;
            set
            {
                _precioActual = value;
                OnPropertyChanged(nameof(PrecioActual));
                txtPrecioActual.Text = value.ToString("C");

                foreach (var inversion in Inversiones)
                {
                    inversion.PrecioActual = value;
                }
            }
        }

        public ViewInversion()
        {
            InitializeComponent();
            DataContext = this;

            ConfigurarGrafico();
            CargarDatosIniciales();
            CargarInversiones();

            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += ActualizarDatos;
            _timer.Start();
        }

        private void ConfigurarGrafico()
        {
            var axisTextPaint = new SolidColorPaint(new SKColor(80, 80, 80));
            var axisSeparatorPaint = new SolidColorPaint(new SKColor(200, 200, 200)) { StrokeThickness = 1 };

            _xAxis = new Axis
            {
                Labeler = value => new DateTime((long)value).ToString("HH:mm"),
                LabelsRotation = 15,
                TextSize = 12,
                LabelsPaint = axisTextPaint,
                SeparatorsPaint = axisSeparatorPaint,
                MinStep = TimeSpan.FromMinutes(5).Ticks,
                ForceStepToMin = true,
                UnitWidth = TimeSpan.FromMinutes(1).Ticks
            };

            _yAxis = new Axis
            {
                Labeler = value => value.ToString("N2"),
                TextSize = 12,
                LabelsPaint = axisTextPaint,
                SeparatorsPaint = axisSeparatorPaint,
                Position = LiveChartsCore.Measure.AxisPosition.End,
                MinLimit = null,
                MaxLimit = null
            };

            _candleSeries = new CandlesticksSeries<CustomOhlcPoint>
            {
                Values = _datos,
                Name = "PRECIO",
                MaxBarWidth = 25,
                UpFill = new SolidColorPaint(new SKColor(0, 200, 0)),
                DownFill = new SolidColorPaint(new SKColor(200, 0, 0)),
                UpStroke = new SolidColorPaint(new SKColor(0, 150, 0)) { StrokeThickness = 2 },
                DownStroke = new SolidColorPaint(new SKColor(150, 0, 0)) { StrokeThickness = 2 },
                TooltipLabelFormatter = point =>
                {
                    var ohlc = (CustomOhlcPoint)point.Model;
                    return $"APERTURA: {ohlc.Open:N2}\n" +
                           $"MÁXIMO:  {ohlc.High:N2}\n" +
                           $"MÍNIMO:  {ohlc.Low:N2}\n" +
                           $"CIERRE:  {ohlc.Close:N2}\n" +
                           $"HORA:    {ohlc.DateTime:HH:mm:ss}";
                },
                Mapping = (ohlc, point) =>
                {
                    point.PrimaryValue = ohlc.HighValue;
                    point.SecondaryValue = ohlc.PointDateTime.Ticks;
                    point.TertiaryValue = ohlc.OpenValue;
                    point.QuaternaryValue = ohlc.CloseValue;
                    point.QuinaryValue = ohlc.LowValue;
                }
            };

            miGrafico.Series = new ISeries[] { _candleSeries };
            miGrafico.XAxes = new[] { _xAxis };
            miGrafico.YAxes = new[] { _yAxis };
        }

        private void CargarDatosIniciales()
        {
            try
            {
                _timer?.Stop();
                _datos.Clear();

                _tipoActivo = ((ComboBoxItem)cmbTipoActivo.SelectedItem)?.Content?.ToString() ?? "Acciones";
                var inicial = _tradingService.GenerarDatosVelas(_tipoActivo, 50);

                foreach (var item in inicial)
                {
                    _datos.Add(item);
                }

                PrecioActual = (decimal)_datos.Last().Close;
                AjustarVistaAlFinal();
            }
            finally
            {
                _timer?.Start();
            }
        }

        private void CargarInversiones()
        {
            try
            {
                var inversiones = _inversionController.ObtenerInversiones(_tipoActivo);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Inversiones.Clear();
                    foreach (var inv in inversiones)
                    {
                        inv.PrecioActual = PrecioActual;
                        Inversiones.Add(inv);
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar inversiones: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void AjustarVistaAlFinal()
        {
            if (_datos.Count == 0) return;

            var endTime = _datos.Last().DateTime;
            var startTime = endTime.AddMinutes(-30);

            _xAxis.MinLimit = startTime.Ticks;
            _xAxis.MaxLimit = endTime.Ticks;

            miGrafico.Series = new[] { _candleSeries };
            miGrafico.XAxes = new[] { _xAxis };
            miGrafico.YAxes = new[] { _yAxis };
        }

        private void ActualizarDatos(object sender, EventArgs e)
        {
            var nuevo = _tradingService.ActualizarDatos(_tipoActivo);

            Application.Current.Dispatcher.Invoke(() =>
            {
                _datos.Add(nuevo);
                if (_datos.Count > 100) _datos.RemoveAt(0);

                PrecioActual = (decimal)nuevo.Close;
                AjustarVistaAlFinal();
            });
        }

        private void CmbTipoActivo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoaded)
            {
                CargarDatosIniciales();
                CargarInversiones();
            }
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            CargarDatosIniciales();
            CargarInversiones();
        }

        private void BtnComprar_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(txtCantidad.Text, out decimal cantidad) && cantidad > 0)
            {
                try
                {
                    var inversion = _inversionController.ComprarActivo(cantidad, _tipoActivo);
                    inversion.PrecioActual = PrecioActual;

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Inversiones.Add(inversion);
                        txtCantidad.Text = "";
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al realizar la compra: {ex.Message}", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese una cantidad válida mayor a cero", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnVender_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button?.CommandParameter is int idInversion)
            {
                try
                {
                    var inversion = Inversiones.FirstOrDefault(i => i.IdInversion == idInversion);
                    if (inversion != null)
                    {
                        var resultado = _inversionController.VenderActivo(inversion.IdInversion, _tipoActivo);

                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            Inversiones.Remove(inversion);
                        });

                        MessageBox.Show($"Operación completada con éxito.\nGanancia/Pérdida: {resultado:C}",
                                      "Venta realizada",
                                      MessageBoxButton.OK,
                                      MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al realizar la venta: {ex.Message}", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("No se pudo obtener la inversión seleccionada", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected override void OnClosed(EventArgs e)
        {
            _timer?.Stop();
            base.OnClosed(e);
        }
    }
}