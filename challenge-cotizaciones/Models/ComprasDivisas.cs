using System;
using System.Collections.Generic;

namespace challenge_cotizaciones.Models
{
    public partial class ComprasDivisas
    {
        public string Divisa { get; set; }
        public int Id { get; set; }
        public long IdUsuario { get; set; }
        public decimal MontoComprado { get; set; }
        public DateTime FechaCompra { get; set; }

        public ComprasDivisas(long IdUsuario, string Divisa, decimal MontoComprado)
        {
            this.IdUsuario = IdUsuario;
            this.Divisa = Divisa;
            this.MontoComprado = MontoComprado;
        }
    }
}
