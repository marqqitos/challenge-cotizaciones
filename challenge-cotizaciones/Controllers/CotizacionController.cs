using System;
using System.Linq;
using System.Threading.Tasks;
using challenge_cotizaciones.Services.Interfaces;
using challenge_cotizaciones.Validators.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace challenge_cotizaciones.Controllers
{
    [Route("api/cotizacion")]
    [ApiController]
    public class CotizacionController : ControllerBase
    {
        private readonly ILogger<CotizacionController> _logger;
        private readonly IDivisasHabilitadasValidator _divisasHabilitadasValidator;
        private readonly ICotizacionService _cotizacionService;

        public CotizacionController(ILogger<CotizacionController> logger, IDivisasHabilitadasValidator divisasHabilitadasValidator,ICotizacionService cotizacionService)
        {
            _logger = logger;
            _divisasHabilitadasValidator = divisasHabilitadasValidator;
            _cotizacionService = cotizacionService;
        }

        [HttpGet("{divisa}")]
        public async Task<ActionResult<decimal>> GetCotizacion(string divisa)
        {
            if (_divisasHabilitadasValidator.EsDivisaHabilitada(divisa)) {
                try
                {
                    return await _cotizacionService.GetCotizacion(divisa.ToLower());
                }
                catch (Exception e)
                {
                    _logger.LogError("Ocurrio un error al intentar obtener la cotizacion de: " + divisa + ", exception: " + e.Data);
                    return StatusCode(500, "Ocurrio un error al intentar obtener la cotizacion de la divisa");
                }
            }
            else
            {
                return BadRequest("No se puede obtener cotizacion de la divisa solicitada");
            }
        }
    }
}