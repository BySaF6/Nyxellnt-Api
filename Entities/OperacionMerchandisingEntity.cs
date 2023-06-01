
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
[Table("OperacionesProductos")]
public class OperacionMerchandisingEntity
{
    [Key]
    public int idOperacionMerchandising { get; set; }
    public int idFestival { get; set; }
    public int idMerchandising { get; set; }
    public int idUsuario { get; set; }
    public int numProductosComprados { get; set; }
    public decimal precioTotalProductos { get; set; }
    public string fechaCompra { get; set; } = DateTime.Now.ToString("dd-MM-yyyy");

}
