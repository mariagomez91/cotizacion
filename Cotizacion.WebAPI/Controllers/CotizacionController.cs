using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cotizacion.Domain;
using Cotizacion.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Cotizacion.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotizacionController : ControllerBase
    {
        private ICotizacionService _cotizacionService;



        public CotizacionController(ICotizacionService cotizacionService)
        {
            _cotizacionService = cotizacionService;

        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "dolar", "euro","real" };
        }

        [HttpGet("{id}")]
        public ActionResult<CotizacionModel> Get(string id)
        {
            try
            {
                return _cotizacionService.GetByMoneda(id);
            }
            catch (Exception ex)
            {

                return NotFound(new { message = ex.Message });
            }            
        }
    }
}