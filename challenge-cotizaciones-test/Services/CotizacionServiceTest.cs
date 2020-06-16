using challenge_cotizaciones.Cotizadores.Interfaces;
using challenge_cotizaciones.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace challenge_cotizaciones_test.Services
{
    public class CotizacionServiceTest
    {
        private Mock<ICotizador> cotizador;
        private CotizacionService service;

        public CotizacionServiceTest()
        {
            cotizador = new Mock<ICotizador>();
            service = new CotizacionService(cotizador.Object);
        }

        [Fact]
        public void CotizacionServiceObtieneCotizacionDelDolar()
        {
            cotizador.Setup(c => c.GetCotizacion("dolar")).Returns(Task.FromResult(72m));

            var result = service.GetCotizacion("dolar");

            cotizador.Verify(c => c.GetCotizacion("dolar"), Times.Once);
            Assert.Equal(72m, result.Result);
        }

        [Fact]
        public void CotizacionServiceObtieneCotizacionDelReal()
        {
            cotizador.Setup(c => c.GetCotizacion("real")).Returns(Task.FromResult(18m));

            var result = service.GetCotizacion("real");

            cotizador.Verify(c => c.GetCotizacion("real"), Times.Once);
            Assert.Equal(18m, result.Result);
        }

    }
}
