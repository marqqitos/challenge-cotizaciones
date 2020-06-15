using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge_cotizaciones.Validators.Interfaces
{
    public interface IDivisasHabilitadasValidator
    {
        public bool EsDivisaHabilitada(string divisaIngresada);
    }
}
