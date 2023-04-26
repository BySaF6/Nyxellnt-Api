
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
[Table("OperacionesProductos")]
public class OperacionProductosEntity
{
    [Key]
    public int idOperacionProductos { get; set; }
    public int idEvento { get; set; }
    public int idProducto { get; set; }
    public int idUsuario { get; set; }
    public int numProductosComprados { get; set; }
    public decimal precioTotal { get; set; }
    public string fechaCompra { get; set; } = DateTime.Now.ToString("dd-MM-yyyy");

}
