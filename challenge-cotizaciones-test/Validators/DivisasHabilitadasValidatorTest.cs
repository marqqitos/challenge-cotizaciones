using challenge_cotizaciones.Validators;
using challenge_cotizaciones.Validators.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace challenge_cotizaciones_test.Validators
{
    public class DivisasHabilitadasValidatorTest
    {
        private IDivisasHabilitadasValidator divisasHabilitadasValidator;

        public DivisasHabilitadasValidatorTest()
        {
            this.divisasHabilitadasValidator = new DivisasHabilitadasValidator();
        }

        [Fact]
        public void DolarEsDivisaHabilitada()
        {
            var habilitada = divisasHabilitadasValidator.EsDivisaHabilitada("dolar");

            Assert.True(habilitada);
        }

        [Fact]
        public void RealEsDivisaHabilitada()
        {
            var habilitada = divisasHabilitadasValidator.EsDivisaHabilitada("real");

            Assert.True(habilitada);
        }

        [Fact]
        public void OtraDivisaNoEsHabilitada()
        {
            var habilitada = divisasHabilitadasValidator.EsDivisaHabilitada("euro");

            Assert.True(!habilitada);
        }
    }
}
