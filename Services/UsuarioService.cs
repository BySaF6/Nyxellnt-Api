using NyxellntAPI.Entities;
public class UsuarioService : UsuarioServiceInterface
{
    private readonly NyxellntDb _context;
    public UsuarioService(NyxellntDb context)
    {
        _context = context;
    }

    // static List<UsuarioEntity> usuarioEntityList { get; }
    // static int nextId = 2;

    public List<UsuarioEntity> GetAll() => _context.Usuarios.ToList();

    public UsuarioEntity Get(int id) => _context.Usuarios.ToList().FirstOrDefault(p => p.idUsuario == id);

    public void Add(UsuarioEntity usuario)
    {
        // usuario.idUsuario = nextId++;
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

    // public void listarInformacionUsuario()
    // {
    //     Console.WriteLine("[bold #13D7F6]Id: [/][bold white]" + _usuarioEntity.idUsuario + "[/]");
    //     Console.WriteLine("[bold #13D7F6]Nombre: [/][bold white]" + _usuarioEntity.nombre + "[/]");
    //     Console.WriteLine("[bold #13D7F6]Apellido: [/][bold white]" + _usuarioEntity.apellido + "[/]");
    //     Console.WriteLine("[bold #13D7F6]Email: [/][bold white]" + _usuarioEntity.email + "[/]");
    //     Console.WriteLine("[bold #13D7F6]Contraseña: [/][bold white]*********[/]");
    // }

    // public UsuarioEntity GetUsuarioEntityById(int idUsuario){
    //     return ;
    // }

    // public List<>
}

