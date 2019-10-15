using Cotizacion.Domain;
using Cotizacion.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cotizacion.Service.Services
{
    public class CotizacionIntService:ICotizacionService
    {
        public CotizacionModel GetByMoneda(string sMoneda)
        {
            //La idea de este metodo seria que vaya a buscar la cotizacion de una base de datos
            //La cual no tuve tiempo de terminar


            CotizacionModel hCotizacion = new CotizacionModel();

            hCotizacion.Moneda = sMoneda;

            return hCotizacion;
        }

    }
}
