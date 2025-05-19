using System;
using LiveChartsCore;
using LiveChartsCore.Kernel;
using LiveChartsCore;
using LiveChartsCore.Kernel;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;

namespace gestorFinanzas.models
{
    public class CustomOhlcPoint 
    {
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public DateTime DateTime { get; set; }

        public CustomOhlcPoint(double open, double high, double low, double close, DateTime dateTime)
        {
            Open = open;
            High = high;
            Low = low;
            Close = close;
            DateTime = dateTime;
        }

        // Implementación de IFinancialPoint
        public double CloseValue => Close;
        public double HighValue => High;
        public double LowValue => Low;
        public double OpenValue => Open;
        public DateTime PointDateTime => DateTime;
    }
}

