using challenge_cotizaciones.Cotizadores.Interfaces;
using challenge_cotizaciones.DTOs;
using challenge_cotizaciones.Models;
using challenge_cotizaciones.Repositories;
using challenge_cotizaciones.Repositories.Interfaces;
using challenge_cotizaciones.Services;
using challenge_cotizaciones.Validators;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace challenge_cotizaciones_test.Services
{
    public class OperacionDivisaServiceValidator
    {
        private OperacionDivisaService operacionDivisaService;
        private ComprarDivisaDTO compra;
        private Mock<IOperacionDivisaRepository> repo;
        private Mock<ICotizador> cotizador;

        public OperacionDivisaServiceValidator()
        {
            repo = new Mock<IOperacionDivisaRepository>();
            repo.Setup(r => r.GetCantidadDivisasCompradasEnElMesPorUsuario(It.IsAny<long>(), It.IsAny<string>())).Returns(100m);
            repo.Setup(r => r.GuardarCompraDivisa(It.IsAny<ComprasDivisas>())).Verifiable();

            cotizador = new Mock<ICotizador>();
            cotizador.Setup(c => c.GetCotizacion("dolar")).Returns(Task.FromResult(72m));

            operacionDivisaService = new OperacionDivisaService(new Mock<ILogger<OperacionDivisaService>>().Object, repo.Object, cotizador.Object, new LimiteMensualValidator());

            compra = new ComprarDivisaDTO();
            compra.IdUsuario = 1;
            compra.Divisa = "dolar";
        }

        [Fact]
        public void CompraSuperaLimiteMensualPorLoTantoDevuelveFalso()
        {
            compra.MontoCompraPesos = 72000m;

            var esFalso = operacionDivisaService.ComprarDivisa(compra);

            repo.Verify(r => r.GetCantidadDivisasCompradasEnElMesPorUsuario(compra.IdUsuario, compra.Divisa), Times.Once);
            repo.Verify(r => r.GuardarCompraDivisa(It.IsAny<ComprasDivisas>()), Times.Never);
            cotizador.Verify(c => c.GetCotizacion(compra.Divisa), Times.Once);
            Assert.False(esFalso.Result);

            var cotizacion = cotizador.Object.GetCotizacion("dolar");
            var cantAComprar = compra.MontoCompraPesos / cotizacion.Result;

            Assert.Equal(1000m, cantAComprar);
        }

        [Fact]
        public void CompraNoSuperaLimiteMensualPorLoTantoDevuelveVerdadero()
        {
            compra.MontoCompraPesos = 3600m;

            var esVerdadero = operacionDivisaService.ComprarDivisa(compra);

            repo.Verify(r => r.GetCantidadDivisasCompradasEnElMesPorUsuario(compra.IdUsuario, compra.Divisa), Times.Once);
            repo.Verify(r => r.GuardarCompraDivisa(It.IsAny<ComprasDivisas>()), Times.Once);
            cotizador.Verify(c => c.GetCotizacion(compra.Divisa), Times.Once);
            Assert.True(esVerdadero.Result);

            var cotizacion = cotizador.Object.GetCotizacion("dolar");
            var cantAComprar = compra.MontoCompraPesos / cotizacion.Result;

            Assert.Equal(50m, cantAComprar);
        }
    }
}
