using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using challenge_cotizaciones.Models;
using challenge_cotizaciones.DTOs;
using challenge_cotizaciones.Services.Interfaces;
using Microsoft.Extensions.Logging;
using challenge_cotizaciones.Validators.Interfaces;

namespace challenge_cotizaciones.Controllers
{
    [Route("api/divisa")]
    [ApiController]
    public class OperacionDivisasController : ControllerBase
    {
        private readonly ILogger<OperacionDivisasController> _logger;
        private readonly IDivisasHabilitadasValidator _divisasHabilitadasValidator;
        private readonly IOperacionDivisaService _operacionDivisaService;

        public OperacionDivisasController(ILogger<OperacionDivisasController> logger, IDivisasHabilitadasValidator divisasHabilitadasValidator , IOperacionDivisaService operacionDivisaService)
        {
            _logger = logger;
            _divisasHabilitadasValidator = divisasHabilitadasValidator;
            _operacionDivisaService = operacionDivisaService;
        }

        [HttpPost("comprar")]
        public async Task<ActionResult> ComprarDivisas(ComprarDivisaDTO compraDivisas)
        {
            if(_divisasHabilitadasValidator.EsDivisaHabilitada(compraDivisas.Divisa))
            {
                try
                {
                    var success = await _operacionDivisaService.ComprarDivisa(compraDivisas);

                    return success ? Ok("Compra de divisas exitosa") : StatusCode(412, "Se supero el limite mensual de compra de la divisa seleccionada");
                }
                catch (Exception e)
                {
                    _logger.LogError("Ocurrio un error al intentar comprar la divisa, exception: " + e.Data);
                    return StatusCode(500, "Ocurrio un error al intentar comprar la divisa");
                }
            }
            else
            {
                return BadRequest("La divisa solicitada no esta habilitada para la compra");
            }
        }
    }
}
