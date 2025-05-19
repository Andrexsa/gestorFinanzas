using System;
using System.Collections.Generic;
using System.Linq;
using gestorFinanzas.models;

namespace gestorFinanzas.services
{
    public class TradingService
    {
        private readonly Random _random = new();
        private DateTime _lastUpdate = DateTime.Now;
        private List<CustomOhlcPoint> _historicalData = new();

        public decimal GenerarPrecioAleatorio(string tipoActivo, decimal? lastPrice = null)
        {
            decimal basePrice = tipoActivo switch
            {
                "Cripto" => (decimal)(_random.NextDouble() * (50000 - 10000) + 10000),
                "Acción" => (decimal)(_random.NextDouble() * (500 - 10) + 10),
                "Divisa" => (decimal)(_random.NextDouble() * (2000 - 100) + 100),
                _ => (decimal)(_random.NextDouble() * 1000)
            };

            if (lastPrice.HasValue)
            {
                decimal variation = (decimal)((_random.NextDouble() * 0.1) - 0.05);
                return lastPrice.Value * (1 + variation);
            }

            return basePrice;
        }

        public List<CustomOhlcPoint> GenerarDatosVelas(string tipoActivo, int cantidadVelas)
        {
            var datos = new List<CustomOhlcPoint>();
            decimal lastClose = GenerarPrecioAleatorio(tipoActivo);

            for (int i = 0; i < cantidadVelas; i++)
            {
                decimal open = lastClose;
                decimal high = open * (decimal)(1 + _random.NextDouble() * 0.05);
                decimal low = open * (decimal)(1 - _random.NextDouble() * 0.05);
                decimal close = open * (decimal)(1 + (_random.NextDouble() * 0.1 - 0.05));

                high = Math.Max(open, Math.Max(high, close));
                low = Math.Min(open, Math.Min(low, close));

                datos.Add(new CustomOhlcPoint((double)open, (double)high, (double)low, (double)close, _lastUpdate));
                _lastUpdate = _lastUpdate.AddMinutes(1);
                lastClose = close;
            }

            _historicalData = datos;
            return datos;
        }

        public CustomOhlcPoint ActualizarDatos(string tipoActivo)
        {
            if (!_historicalData.Any())
            {
                _historicalData = GenerarDatosVelas(tipoActivo, 1);
                return _historicalData.Last();
            }

            var lastPoint = _historicalData.Last();
            decimal lastClose = (decimal)lastPoint.Close;

            decimal open = lastClose;
            decimal high = open * (decimal)(1 + _random.NextDouble() * 0.05);
            decimal low = open * (decimal)(1 - _random.NextDouble() * 0.05);
            decimal close = open * (decimal)(1 + (_random.NextDouble() * 0.1 - 0.05));

            high = Math.Max(open, Math.Max(high, close));
            low = Math.Min(open, Math.Min(low, close));

            _lastUpdate = _lastUpdate.AddMinutes(1);
            var newPoint = new CustomOhlcPoint((double)open, (double)high, (double)low, (double)close, _lastUpdate);
            _historicalData.Add(newPoint);

            if (_historicalData.Count > 100)
                _historicalData.RemoveAt(0);

            return newPoint;
        }

        public decimal ObtenerValorActual(string tipoActivo)
        {
            if (!_historicalData.Any())
                GenerarDatosVelas(tipoActivo, 10);

            return (decimal)_historicalData.Last().Close;
        }
    }
}