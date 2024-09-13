using _NEXUS.Models;
using _NEXUS.Models.Mapping;
using Microsoft.EntityFrameworkCore;

namespace NX.Database
{
    public class NXContext : DbContext
    {
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ProdutosModel> Produtos { get; set; }
        public DbSet<PedidosModel> Pedidos { get; set; }

        public NXContext(DbContextOptions<NXContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new ProdutosMapping());
            modelBuilder.ApplyConfiguration(new PedidosMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}