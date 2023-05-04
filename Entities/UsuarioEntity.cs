using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
[Table("Usuarios")]
public class UsuarioEntity
{
    [Key]
    public int idUsuario { get; set; }
    public string nombre { get; set; }
    public string apellido { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string rol { get; set;}
}
