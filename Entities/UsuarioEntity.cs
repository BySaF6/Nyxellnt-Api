using System;

public class UsuarioEntity
{
    public int idUsuario { get; set; }
    public static int accountNumber = 1;
    public string nombre { get; set; }
    public string apellido { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public List<OperacionEntity> eventosComprados { get; set; }

}
