using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge_cotizaciones.Cotizadores.Interfaces
{
    public interface ICotizador
    {
        public Task<double> GetCotizacion(String divisa);
    }
}
