using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge_cotizaciones.DTOs
{
    public class ComprarDivisaDTO
    {
        public long IdUsuario { get; set; }
        public decimal MontoCompraPesos { get; set; }
        public string Divisa { get; set; }
    }
}
