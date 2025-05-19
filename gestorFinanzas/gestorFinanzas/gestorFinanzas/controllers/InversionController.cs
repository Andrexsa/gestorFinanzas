using AppFinanciera.Models;
using AppFinanciera.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppFinanciera.Controllers
{
    public class InversionController
    {
        private readonly InversionService _inversionService = new InversionService();
        private readonly TradingService _tradingService = new TradingService();

        public Inversion ComprarActivo(decimal cantidad, string tipoActivo)
        {
            var precioActual = _tradingService.ObtenerValorActual(tipoActivo);

            var inversion = new Inversion
            {
                Cantidad = cantidad,
                Precio = precioActual,
                Tiempo = DateTime.Now,
                Activo = new Activo { Nombre = tipoActivo }
            };

            _inversionService.GuardarInversion(inversion);
            return inversion;
        }

        public decimal VenderActivo(int idInversion, string tipoActivo)
        {
            var precioActual = _tradingService.ObtenerValorActual(tipoActivo);
            var inversion = _inversionService.ObtenerInversionPorId(idInversion, precioActual);

            if (inversion != null)
            {
                var ganancia = inversion.Ganancia;
                _inversionService.EliminarInversion(idInversion);
                return ganancia;
            }

            return 0;
        }

        public List<Inversion> ObtenerInversiones(string tipoActivo)
        {
            var idActivo = _inversionService.ObtenerOInsertarActivo(tipoActivo);
            var precioActual = _tradingService.ObtenerValorActual(tipoActivo);
            return _inversionService.ObtenerInversionesPorActivo(idActivo, precioActual);
        }
    }
}