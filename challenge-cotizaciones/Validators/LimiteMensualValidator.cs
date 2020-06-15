using challenge_cotizaciones.Validators.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge_cotizaciones.Validators
{
    public class LimiteMensualValidator : ILimiteMensualValidator
    {
        private readonly Dictionary<string, decimal> limiteDivisa;

        public LimiteMensualValidator()
        {
            limiteDivisa = new Dictionary<string, decimal>
            {
                { "dolar", 200 },
                { "real", 300 }
            };
        }

        public bool SuperaMontoLimiteMensual(string divisa, decimal cantAdquirida, decimal cantAAdquirir)
        {
            var limite = limiteDivisa.GetValueOrDefault(divisa);

            return cantAdquirida + cantAAdquirir > limite;
        }
    }
}
