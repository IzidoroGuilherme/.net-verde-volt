using Fiap.Api.VerdeVolt.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.VerdeVolt.Data
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<MatrizEnergeticaModel> MatrizEnergetica { get; set; }
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MatrizEnergeticaModel>(entity =>
            {
                entity.ToTable("MatrizEnergeticaVerdeVolt");
                entity.HasKey(e => e.MatrizId);
                entity.Property(e => e.Pais).IsRequired();
            });
            base.OnModelCreating(modelBuilder);
        }       
    }
}
