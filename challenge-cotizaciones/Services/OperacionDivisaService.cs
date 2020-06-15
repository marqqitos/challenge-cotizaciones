using challenge_cotizaciones.Cotizadores.Interfaces;
using challenge_cotizaciones.DTOs;
using challenge_cotizaciones.Models;
using challenge_cotizaciones.Repositories.Interfaces;
using challenge_cotizaciones.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge_cotizaciones.Services
{
    public class OperacionDivisaService : IOperacionDivisaService
    {
        private readonly IOperacionDivisaRepository _repository;
        private readonly ICotizador _cotizador;

        public OperacionDivisaService(IOperacionDivisaRepository repo, ICotizador cotizador)
        {
            _repository = repo;
            _cotizador = cotizador;
        }

        public async Task ComprarDivisa(ComprarDivisaDTO compra)
        {
            var cotizacion = await _cotizador.GetCotizacion(compra.Divisa);
            var compraDivisa = new ComprasDivisas(compra.IdUsuario, compra.Divisa, compra.MontoCompraPesos / cotizacion);

            await _repository.GuardarCompraDivisa(compraDivisa);
        }

        public async Task<List<ComprasDivisas>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
