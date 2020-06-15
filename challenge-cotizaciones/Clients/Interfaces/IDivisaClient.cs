using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge_cotizaciones.Clients.Interfaces
{
    public interface IDivisaClient
    {
        public Task<double> GetCotizacion();
    }
}
