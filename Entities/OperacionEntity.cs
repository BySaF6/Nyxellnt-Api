
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
[Table("Operaciones")]
public class OperacionEntity
{
    [Key]
    public int idOperacion { get; set; }
    public static int operationNumber = 1;
    public EventoEntity eventoComprado { get; set; }
    public int numEntradasCompradas { get; set; }
    public decimal precioTotal { get; set; }
    public string fechaCompra = DateTime.Now.ToString("dd-MM-yyyy");

}
