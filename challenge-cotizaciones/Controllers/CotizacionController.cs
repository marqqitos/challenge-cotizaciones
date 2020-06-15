using System;
using System.Linq;
using System.Threading.Tasks;
using challenge_cotizaciones.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace challenge_cotizaciones.Controllers
{
    [Route("api/cotizacion")]
    [ApiController]
    public class CotizacionController : ControllerBase
    {
        private readonly ILogger<CotizacionController> _logger;
        private ICotizacionService _cotizacionService;

        private static readonly string[] DivisasAceptadas = new[]
        {
            "dolar", "real"
        };

        public CotizacionController(ILogger<CotizacionController> logger, ICotizacionService cotizacionService)
        {
            _logger = logger;
            _cotizacionService = cotizacionService;
        }

        [HttpGet("{divisa}")]
        public async Task<ActionResult<decimal>> GetCotizacion(string divisa)
        {
            if (!DivisasAceptadas.Contains(divisa.ToLower())) {
                return BadRequest("No se puede obtener cotizacion de la divisa solicitada");
            }
            else
            {
                try
                {
                    return await _cotizacionService.GetCotizacion(divisa.ToLower());
                }
                catch(Exception e)
                {
                    _logger.LogError("Ocurrio un error al intentar obtener la cotizacion de: " + divisa + ", exception: " + e.Data);
                    return StatusCode(500, "Ocurrio un error al intentar obtener la cotizacion de la divisa");
                }
            }
        }
    }
}