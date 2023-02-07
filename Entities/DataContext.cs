using Microsoft.EntityFrameworkCore;

namespace NyxellntAPI.Entities
{
    public class NyxellntDb : DbContext
    {
        public NyxellntDb(DbContextOptions options) : base(options) { }
        public DbSet<EventoEntity> Eventos { get; set; } = null!;
        public DbSet<OperacionEntity> Operaciones { get; set; } = null!;
        public DbSet<UsuarioEntity> Usuarios { get; set; } = null!;
    }
}