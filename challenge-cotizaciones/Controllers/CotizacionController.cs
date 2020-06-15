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

        private static readonly string[] Divisas = new[]
        {
            "dolar", "real"
        };

        public CotizacionController(ILogger<CotizacionController> logger, ICotizacionService cotizacionService)
        {
            _logger = logger;
            _cotizacionService = cotizacionService;
        }

        [HttpGet("{divisa}")]
        public async Task<ActionResult<double>> GetCotizacion(string divisa)
        {
            if (!Divisas.Contains(divisa.ToLower())) {
                return BadRequest("No se puede obtener cotizacion de la divisa solicitada");
            }
            else
            {
                return await _cotizacionService.GetCotizacion(divisa.ToLower());
            }
        }
    }
}