using challenge_cotizaciones.Clients.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace challenge_cotizaciones.Clients
{
    public class RealClient : IDivisaClient
    {
        public HttpClient Client { get; }
        private readonly ILogger<RealClient> _logger;

        public RealClient(ILogger<RealClient> logger, HttpClient client)
        {
            _logger = logger;
            client.BaseAddress = new Uri("https://www.bancoprovincia.com.ar/");
            client.DefaultRequestHeaders.Add("Accept",
                "application/json");

            Client = client;
        }

        public async Task<double> GetCotizacion()
        {
            var response = await Client.GetAsync("Principal/Dolar");
            
            try
            {
                response.EnsureSuccessStatusCode();

                List<string> values = JsonConvert.DeserializeObject<List<string>>(response.Content.ReadAsStringAsync().Result);

                return (double.Parse(values.ElementAt(1), CultureInfo.InvariantCulture) / 4);
            }

            catch(HttpRequestException e)
            {
                _logger.LogError("Error al consultar la cotizacion del real, status code: " + response.StatusCode + ", exception: " + e.Data);
                throw;
            }
            catch(Exception e)
            {
                _logger.LogError("Error al obtener la cotizacion del real, exception: " + e.Data);
                throw;
            }
        }
    }
}
