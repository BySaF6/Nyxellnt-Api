using NyxellntAPI.Entities;
public class UsuarioService : UsuarioServiceInterface
{
    private readonly NyxellntDb _context;
    public UsuarioService(NyxellntDb context)
    {
        _context = context;
    }

    public List<UsuarioEntity> GetAll() => _context.Usuarios.ToList();

    public UsuarioEntity Get(int id) => _context.Usuarios.ToList().FirstOrDefault(p => p.idUsuario == id);

    public void Add(UsuarioEntity usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var usuario = Get(id);
        if (usuario is null)
            return;

        _context.Remove(usuario);
        _context.SaveChanges();
    }

    public void Update(UsuarioEntity usuarioEntity)
    {
        _context.Update(usuarioEntity);
        _context.SaveChanges();
    }
}

