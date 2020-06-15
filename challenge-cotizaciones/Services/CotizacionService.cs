using challenge_cotizaciones.Cotizadores.Interfaces;
using challenge_cotizaciones.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge_cotizaciones.Services
{
    public class CotizacionService : ICotizacionService
    {
        private ICotizador _cotizador;

        public CotizacionService(ICotizador cotizador)
        {
            _cotizador = cotizador;
        }

        public async Task<double> GetCotizacion(string divisa)
        {
            return await _cotizador.GetCotizacion(divisa);
        }
    }
}
