using challenge_cotizaciones.Cotizadores.Interfaces;
using challenge_cotizaciones.DTOs;
using challenge_cotizaciones.Models;
using challenge_cotizaciones.Repositories.Interfaces;
using challenge_cotizaciones.Services.Interfaces;
using challenge_cotizaciones.Validators.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge_cotizaciones.Services
{
    public class OperacionDivisaService : IOperacionDivisaService
    {
        private readonly ILogger<OperacionDivisaService> _logger;
        private readonly IOperacionDivisaRepository _repository;
        private readonly ICotizador _cotizador;
        private readonly ILimiteMensualValidator _limiteMensualValidator;

        public OperacionDivisaService(ILogger<OperacionDivisaService> logger, IOperacionDivisaRepository repo, ICotizador cotizador, ILimiteMensualValidator limiteMensualValidator)
        {
            _logger = logger;
            _repository = repo;
            _cotizador = cotizador;
            _limiteMensualValidator = limiteMensualValidator;
        }

        public async Task<bool> ComprarDivisa(ComprarDivisaDTO compra)
        {
            var cantidadDivisasCompradas = _repository.GetCantidadDivisasCompradasEnElMesPorUsuario(compra.IdUsuario, compra.Divisa);
            var cotizacion = await _cotizador.GetCotizacion(compra.Divisa);
            var cantAComprar = compra.MontoCompraPesos / cotizacion;

            if(_limiteMensualValidator.SuperaMontoLimiteMensual(compra.Divisa, cantidadDivisasCompradas, cantAComprar))
            {
                _logger.LogError("Limite mensual superado para la divisa elegida");
                return false;
            }
            else
            {
                var compraDivisa = new ComprasDivisas(compra.IdUsuario, compra.Divisa, cantAComprar);
                await _repository.GuardarCompraDivisa(compraDivisa);
                return true;
            }
            
        }
    }
}
