
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
[Table("Operaciones")]
public class OperacionEntity
{
    [Key]
    public int idOperacion { get; set; }
    public int idEvento { get; set; }
    public int idUsuario {get; set; }
    public int numEntradasCompradas { get; set; }
    public decimal precioTotal { get; set; }
    public string fechaCompra { get; set; } = DateTime.Now.ToString("dd-MM-yyyy"); 
}
