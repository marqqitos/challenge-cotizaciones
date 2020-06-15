using challenge_cotizaciones.Clients.Interfaces;
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

        public RealClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://www.bancoprovincia.com.ar/");
            client.DefaultRequestHeaders.Add("Accept",
                "application/json");

            Client = client;
        }

        public async Task<double> GetCotizacion()
        {
            var response = await Client.GetAsync("Principal/Dolar");

            response.EnsureSuccessStatusCode();

            List<string> values = JsonConvert.DeserializeObject<List<string>>(response.Content.ReadAsStringAsync().Result);

            return (double.Parse(values.ElementAt(1), CultureInfo.InvariantCulture) / 4);
        }
    }
}
