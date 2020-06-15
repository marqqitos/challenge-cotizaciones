using Castle.Core.Logging;
using challenge_cotizaciones.Clients;
using challenge_cotizaciones.Clients.Interfaces;
using challenge_cotizaciones.Cotizadores;
using challenge_cotizaciones.Cotizadores.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace challenge_cotizaciones_test
{
    public class CotizadorTest
    {
        private ICotizador _cotizador;
        private Mock<IDivisaClient> dolarClient;
        private Mock<IDivisaClient> realClient;

        public CotizadorTest()
        {
            dolarClient = new Mock<IDivisaClient>();
            realClient = new Mock<IDivisaClient>();
            _cotizador = new Cotizador(dolarClient.Object, realClient.Object);
        }

        [Fact]
        public void CotizadorObtieneCorrectaCotizacionDelDolar()
        {
            dolarClient.Setup(dc => dc.GetCotizacion()).Returns(Task.FromResult(72d));

            var result = _cotizador.GetCotizacion("dolar");

            dolarClient.Verify(dc => dc.GetCotizacion(), Times.Once);
            Assert.Equal(72d, result.Result);
        }

        [Fact]
        public void CotizadorObtieneCorrectaCotizacionDelReal()
        {
            realClient.Setup(rc => rc.GetCotizacion()).Returns(Task.FromResult(18d));
            var result = _cotizador.GetCotizacion("real");

            realClient.Verify(rc => rc.GetCotizacion(), Times.Once);
            Assert.Equal(18d, result.Result);
        }
    }
}
