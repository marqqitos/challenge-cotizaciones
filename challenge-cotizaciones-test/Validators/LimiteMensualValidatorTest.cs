using challenge_cotizaciones.Validators;
using challenge_cotizaciones.Validators.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace challenge_cotizaciones_test.Validators
{
    public class LimiteMensualValidatorTest
    {
        private ILimiteMensualValidator limiteMensualValidator;

        public LimiteMensualValidatorTest()
        {
            limiteMensualValidator = new LimiteMensualValidator();
        }

        [Fact]
        public void PorDebajoDelLimiteMensualDelDolarEsValido()
        {
            var supera = limiteMensualValidator.SuperaMontoLimiteMensual("dolar", 100, 50);

            Assert.True(!supera);
        }

        [Fact]
        public void IgualAlLimiteMensualDelDolarEsValido()
        {
            var supera = limiteMensualValidator.SuperaMontoLimiteMensual("dolar", 100, 100);

            Assert.True(!supera);
        }

        [Fact]
        public void PorEncimaDelLimiteMensualDelDolarEsInvalido()
        {
            var supera = limiteMensualValidator.SuperaMontoLimiteMensual("dolar", 100, 150);

            Assert.True(supera);
        }

        [Fact]
        public void PorDebajoDelLimiteMensualDelRealEsValido()
        {
            var supera = limiteMensualValidator.SuperaMontoLimiteMensual("real", 100, 50);

            Assert.True(!supera);
        }
        [Fact]
        public void IgualAlLimiteMensualDelRealEsValido()
        {
            var supera = limiteMensualValidator.SuperaMontoLimiteMensual("real", 100, 200);

            Assert.True(!supera);
        }
        [Fact]
        public void PorEncimaDelLimiteMensualDelRealEsInvalido()
        {
            var supera = limiteMensualValidator.SuperaMontoLimiteMensual("real", 100, 250);

            Assert.True(supera);
        }
    }
}
