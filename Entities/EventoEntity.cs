
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
[Table("Eventos")]
public class EventoEntity
{
    [Key]
    public int idEvento { get; set; }
    public string nombre { get; set; }
    public string cantante { get; set; }
    public string descripcion { get; set; }
    public string localidad { get; set; }
    public string fecha { get; set; }
    public decimal precioEntrada { get; set; }
    public int stock { get; set; }
    public decimal precioEntradaVip { get; set; }
    public int stockVip { get; set; }
    public string categoria { get; set; }
}