using Cotizacion.Domain;
using Cotizacion.Service.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Cotizacion.Service.Services
{
    public class CotizacionExtService: ICotizacionService
    {
        private readonly IOptions<ConfigurationService> _configurationService;
        private Dictionary<string, string> _dicMonedas = new Dictionary<string, string>();


        private string _baseUrl = "";
        private string _key = "";
        


        public CotizacionExtService(IOptions<ConfigurationService> configurationservice)
        {
            _configurationService = configurationservice;
            _baseUrl = _configurationService.Value.CambioToday.URL;
            _key = _configurationService.Value.CambioToday.Key;


            _dicMonedas.Add("dolar", "USA");
            _dicMonedas.Add("euro", "EUR");
            _dicMonedas.Add("real", "BRA");
        }


        public CotizacionModel GetByMoneda(string sMoneda)
        {
            
            CotizacionModel hCotizacion = new CotizacionModel();
            string sCodigoMoneda;
            string sParametros = "quotes/ARG/{0}/json?quantity=1&key={1}";

            try
            {
                sCodigoMoneda = _dicMonedas[sMoneda.ToLower()];
            }
            catch (Exception)
            {

                throw new Exception("No se ha encontrado la moneda que desea consultar.");
            }


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);

                hCotizacion.Moneda = sMoneda;
                try
                {
                    var httpResponse = client.GetAsync(sParametros.Replace("{0}", sMoneda).Replace("{1}", _key)).GetAwaiter().GetResult();

                    var content = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult().ToString();

                    dynamic cotizacion = JsonConvert.DeserializeObject(content);

                    hCotizacion.Precio = cotizacion.result.value;
                }
                catch (Exception)
                {

                    throw new Exception("Error de comunicación.");
                }

            }

            return hCotizacion;
        }
    }
}
