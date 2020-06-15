using challenge_cotizaciones.DTOs;
using challenge_cotizaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge_cotizaciones.Repositories.Interfaces
{
    public interface IOperacionDivisaRepository
    {
        public Task GuardarCompraDivisa(ComprasDivisas compra);
        public decimal GetCantidadDivisasCompradasEnElMesPorUsuario(long idUsuario, string divisa);
    }
}
