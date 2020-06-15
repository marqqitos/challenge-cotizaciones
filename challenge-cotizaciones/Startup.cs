using challenge_cotizaciones.Clients;
using challenge_cotizaciones.Clients.Interfaces;
using challenge_cotizaciones.Cotizadores;
using challenge_cotizaciones.Cotizadores.Interfaces;
using challenge_cotizaciones.Services;
using challenge_cotizaciones.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace challenge_cotizaciones
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<ICotizacionService, CotizacionService>();
            services.AddScoped<ICotizador, Cotizador>(serviceProvider => {
                IDivisaClient dolarClient = serviceProvider.GetService<DolarClient>();
                IDivisaClient realClient = serviceProvider.GetService<RealClient>();
                return new Cotizador(dolarClient, realClient);
            });
            services.AddHttpClient<DolarClient>();
            services.AddHttpClient<RealClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
