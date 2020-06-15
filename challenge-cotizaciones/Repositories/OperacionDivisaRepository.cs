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

        public async Task<List<ComprasDivisas>> GetAll()
        {
            try
            {
                return await _context.ComprasDivisas.ToListAsync();
            }
            catch (Exception)
            {
                return await _context.ComprasDivisas.ToListAsync();
            }

            
        }

        public async Task GuardarCompraDivisa(ComprasDivisas compra)
        {
            _context.ComprasDivisas.Add(compra);
            await _context.SaveChangesAsync();
        }
    }
}
