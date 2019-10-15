using Cotizacion.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cotizacion.Service.Interfaces
{
    public interface ICotizacionService
    {
        /// <summary>
        /// Este metodo devuelve la cotizacion segun la moneda
        /// </summary>
        /// <param name="sMoneda">descripcion de la moneda: dolar,euro o real</param>
        /// <returns></returns>
        CotizacionModel GetByMoneda(string sMoneda);
    }
}
