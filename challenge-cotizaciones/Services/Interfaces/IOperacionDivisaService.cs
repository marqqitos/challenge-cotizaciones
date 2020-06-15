using challenge_cotizaciones.DTOs;
using challenge_cotizaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge_cotizaciones.Services.Interfaces
{
    public interface IOperacionDivisaService
    {
        public Task ComprarDivisa(ComprarDivisaDTO compra);
        public Task<List<ComprasDivisas>> GetAll();
    }
}
