
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
[Table("Festivales")]
public class FestivalEntity
{
    [Key]
    public int idFestival { get; set; }
    public string nombre { get; set; }
    public string artistas { get; set; }
    public string descripcion { get; set; }
    public string localidad { get; set; }
    public string fecha { get; set; }
    public decimal precioEntrada { get; set; }
    public int stock { get; set; }
    public decimal precioEntradaVip { get; set; }
    public int stockVip { get; set; }
    public string mes { get; set; }
    public string imagen { get; set; }
}