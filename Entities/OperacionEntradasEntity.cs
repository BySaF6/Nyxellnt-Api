
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
[Table("OperacionesEntradas")]
public class OperacionEntradasEntity
{
    [Key]
    public int idOperacionEntradas { get; set; }
    public int idFestival { get; set; }
    public int idUsuario { get; set; }
    public int numEntradasCompradas { get; set; }
    public int numEntradasVipCompradas { get; set; }
    public decimal precioTotalEntradas { get; set; }
    public string fechaCompra { get; set; } = DateTime.Now.ToString("dd-MM-yyyy");
}
