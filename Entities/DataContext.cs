using Microsoft.EntityFrameworkCore;

namespace NyxellntAPI.Entities
{
    public class NyxellntDb : DbContext
    {
        public NyxellntDb(DbContextOptions options) : base(options) { }
        public DbSet<EventoEntity> Eventos { get; set; }
        public DbSet<OperacionEntity> Operaciones { get; set; }
        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<MerchandisingEntity> Merchandising { get; set; }
    }
}