using System;
using System.Collections.Generic;
using System.Text;

namespace Cotizacion.Service
{
    public class ConfigurationService
    {
        public ConfigurationCambioToday CambioToday { get; set; }
    }

    public class ConfigurationCambioToday
    {
        public string URL { get; set; }
        public string Key { get; set; }
    }
}
