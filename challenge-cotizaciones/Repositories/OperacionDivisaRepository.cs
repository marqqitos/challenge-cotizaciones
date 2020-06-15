using challenge_cotizaciones.DatabaseContext;
using challenge_cotizaciones.DTOs;
using challenge_cotizaciones.Models;
using challenge_cotizaciones.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge_cotizaciones.Repositories
{
    public class OperacionDivisaRepository : IOperacionDivisaRepository
    {
        private readonly OperacionesDivisasContext _context;

        public OperacionDivisaRepository(OperacionesDivisasContext context)
        {
            _context = context;
        }

        public decimal GetCantidadDivisasCompradasEnElMesPorUsuario(long idUsuario, string divisa)
        {
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            try
            {
                var result = _context.ComprasDivisas
                    .Where(cd => cd.IdUsuario.Equals(idUsuario) 
                    && cd.FechaCompra >= startDate 
                    && cd.FechaCompra <= endDate 
                    && cd.Divisa.Equals(divisa))
                    .Sum(cd => cd.MontoComprado);
                
                return result;
            }
            catch (Exception)
            {
                return 0;
            }

            
        }

        public async Task GuardarCompraDivisa(ComprasDivisas compra)
        {
            _context.ComprasDivisas.Add(compra);
            await _context.SaveChangesAsync();
        }
    }
}
