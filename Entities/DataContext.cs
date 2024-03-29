using Microsoft.EntityFrameworkCore;

namespace NyxellntAPI.Entities
{
    public class NyxellntDb : DbContext
    {
        public NyxellntDb(DbContextOptions options) : base(options) { }
        public DbSet<FestivalEntity> Festivales { get; set; }
        public DbSet<OperacionEntradasEntity> OperacionesEntradas { get; set; }
        public DbSet<OperacionMerchandisingEntity> OperacionesProductos { get; set; }
        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<MerchandisingEntity> Merchandising { get; set; }
    }
}