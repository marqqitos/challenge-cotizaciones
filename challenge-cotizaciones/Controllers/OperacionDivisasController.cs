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

namespace challenge_cotizaciones.Controllers
{
    [Route("api/divisa")]
    [ApiController]
    public class OperacionDivisasController : ControllerBase
    {
        private readonly ILogger<OperacionDivisasController> _logger;
        private readonly IOperacionDivisaService _operacionDivisaService;

        public OperacionDivisasController(ILogger<OperacionDivisasController> logger, IOperacionDivisaService operacionDivisaService)
        {
            _logger = logger;
            _operacionDivisaService = operacionDivisaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ComprasDivisas>>> Get()
        {
            var ocd = await _operacionDivisaService.GetAll();

            return Ok(ocd);
        }

        [HttpPost("comprar")]
        public async Task<ActionResult> PostDivisasCompradasMes(ComprarDivisaDTO compraDivisas)
        {
            try
            {
                await _operacionDivisaService.ComprarDivisa(compraDivisas);
                return Ok("Compra de divisas exitosa");
            }
            catch (Exception e)
            {
                _logger.LogError("Ocurrio un error al intentar comprar la divisa, exception: " + e.Data);
                return StatusCode(500, "Ocurrio un error al intentar comprar la divisa");
            }
        }
    }
}
