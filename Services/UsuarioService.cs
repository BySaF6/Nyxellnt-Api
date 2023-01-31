public class UsuarioService : UsuarioServiceInterface
{
    private readonly UsuarioEntity _usuarioEntity;
    public UsuarioService(UsuarioEntity usuarioEntity)
    {
        _usuarioEntity = usuarioEntity;
    }
    public void listarInformacionUsuario()
    {
        Console.WriteLine("[bold #13D7F6]Id: [/][bold white]" + _usuarioEntity.idUsuario + "[/]");
        Console.WriteLine("[bold #13D7F6]Nombre: [/][bold white]" + _usuarioEntity.nombre + "[/]");
        Console.WriteLine("[bold #13D7F6]Apellido: [/][bold white]" + _usuarioEntity.apellido + "[/]");
        Console.WriteLine("[bold #13D7F6]Email: [/][bold white]" + _usuarioEntity.email + "[/]");
        Console.WriteLine("[bold #13D7F6]Contraseña: [/][bold white]*********[/]");
    }

    public UsuarioEntity GetUsuarioEntityById(int idUsuario){
        return ;
    }

    public List<>
}

