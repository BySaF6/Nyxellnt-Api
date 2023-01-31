public class UsuarioService : UsuarioServiceInterface
{
    private readonly UsuarioEntity _usuarioEntity;
    public UsuarioService(UsuarioEntity usuarioEntity)
    {
        _usuarioEntity = usuarioEntity;
    }

    static List<UsuarioEntity> usuarioEntityList { get; }
    static int nextId = 2;

    public static List<UsuarioEntity> GetAll() => usuarioEntityList;

    public static UsuarioEntity? Get(int id) => usuarioEntityList.FirstOrDefault(p => p.idUsuario == id);

    public static void Add(UsuarioEntity usuario)
    {
        usuario.idUsuario = nextId++;
        usuarioEntityList.Add(usuario);
    }

    public static void Delete(int id)
    {
        var usuario = Get(id);
        if (usuario is null)
            return;

        usuarioEntityList.Remove(usuario);
    }

    public static void Update(UsuarioEntity usuario)
    {
        var index = usuarioEntityList.FindIndex(p => p.idUsuario == usuario.idUsuario);
        if (index == -1)
            return;

        usuarioEntityList[index] = usuario;
    }

    public void listarInformacionUsuario()
    {
        Console.WriteLine("[bold #13D7F6]Id: [/][bold white]" + _usuarioEntity.idUsuario + "[/]");
        Console.WriteLine("[bold #13D7F6]Nombre: [/][bold white]" + _usuarioEntity.nombre + "[/]");
        Console.WriteLine("[bold #13D7F6]Apellido: [/][bold white]" + _usuarioEntity.apellido + "[/]");
        Console.WriteLine("[bold #13D7F6]Email: [/][bold white]" + _usuarioEntity.email + "[/]");
        Console.WriteLine("[bold #13D7F6]Contraseña: [/][bold white]*********[/]");
    }

    // public UsuarioEntity GetUsuarioEntityById(int idUsuario){
    //     return ;
    // }

    // public List<>
}

