using challenge_cotizaciones.Validators.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge_cotizaciones.Validators
{
    public class DivisasHabilitadasValidator : IDivisasHabilitadasValidator
    {
        private static readonly string[] DivisasAceptadas = new[]
        {
            "dolar", "real"
        };

        public bool EsDivisaHabilitada(string divisaIngresada)
        {
            return DivisasAceptadas.Contains(divisaIngresada.ToLower());
        }
    }
}
