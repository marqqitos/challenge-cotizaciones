using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge_cotizaciones.Services.Interfaces
{
    public interface ICotizacionService
    {
        public Task<decimal> GetCotizacion(string divisa);
    }
}
