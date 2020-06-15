using challenge_cotizaciones.Clients;
using challenge_cotizaciones.Clients.Interfaces;
using challenge_cotizaciones.Cotizadores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace challenge_cotizaciones.Cotizadores
{
    public class Cotizador : ICotizador
    {
        private readonly Dictionary<string, IDivisaClient> serviciosCotizacion;

        public Cotizador(DolarClient dolarClient, RealClient realClient)
        {
            serviciosCotizacion = new Dictionary<string, IDivisaClient>();
            serviciosCotizacion.Add("dolar", dolarClient);
            serviciosCotizacion.Add("real", realClient);
        }

        public async Task<double> GetCotizacion(string divisa)
        {
            return await serviciosCotizacion.GetValueOrDefault(divisa).GetCotizacion();
        }
    }
}
