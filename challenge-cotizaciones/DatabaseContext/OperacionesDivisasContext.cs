using challenge_cotizaciones.Models;
using Microsoft.EntityFrameworkCore;

namespace challenge_cotizaciones.DatabaseContext
{
    public partial class OperacionesDivisasContext : DbContext
    {
        public OperacionesDivisasContext()
        {
        }

        public OperacionesDivisasContext(DbContextOptions<OperacionesDivisasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ComprasDivisas> ComprasDivisas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComprasDivisas>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('\"Compras_id_seq\"'::regclass)");

                entity.Property(e => e.Divisa)
                    .IsRequired()
                    .HasColumnName("divisa");

                entity.Property(e => e.FechaCompra)
                    .HasColumnName("fechaCompra")
                    .HasColumnType("date")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.MontoComprado).HasColumnName("montoComprado");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
