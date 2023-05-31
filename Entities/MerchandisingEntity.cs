
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
[Table("Merchandising")]
public class MerchandisingEntity
{
    [Key]
    public int idMerchandising { get; set; }
    public int idFestival { get; set; }
    public string tipoProducto { get; set; }
    public string nombreProducto { get; set; }
    public decimal precioProducto { get; set; }
    public string descripcionProducto { get; set; }
    public int stockProducto { get; set; }
    public byte[] imagen { get; set; }
}