﻿using challenge_cotizaciones.Clients;
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

        public Cotizador(IDivisaClient dolarClient, IDivisaClient realClient)
        {
            serviciosCotizacion = new Dictionary<string, IDivisaClient>
            {
                { "dolar", dolarClient },
                { "real", realClient }
            };
        }

        public async Task<decimal> GetCotizacion(string divisa)
        {
            return await serviciosCotizacion.GetValueOrDefault(divisa).GetCotizacion();
        }
    }
}
