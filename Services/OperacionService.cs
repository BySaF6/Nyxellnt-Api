using NyxellntAPI.Entities;
public class OperacionService : OperacionServiceInterface
{
    private readonly NyxellntDb _context;
    public OperacionService(NyxellntDb context)
    {
        _context = context;
    }

    // static List<OperacionEntity> Operaciones { get; }
    // static int nextId = 1;

    public List<OperacionEntity> GetAll() => _context.Operaciones.ToList();

    public OperacionEntity Get(int id) => _context.Operaciones.ToList().FirstOrDefault(p => p.idOperacion == id);

    public void Add(OperacionEntity operacion)
    {
        // operacion.idOperacion = nextId++;
        _context.Add(operacion);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var operacion = Get(id);
        if (operacion is null)
            return;

        _context.Remove(operacion);
        _context.SaveChanges();
    }

    public void Update(OperacionEntity operacionEntity)
    {
        _context.Update(operacionEntity);
        _context.SaveChanges();
    }
    // public void mostrarOperacion()
    // {
    //     Console.WriteLine("[bold #13D7F6]Id de la operación: [/][bold white]" + _operacionEntity.idOperacion + "[/]");
    //     Console.WriteLine("[bold #13D7F6]Nombre: [/][bold white]" + _operacionEntity.eventoComprado.nombre + "[/]");
    //     Console.WriteLine("[bold #13D7F6]Cantante: [/][bold white]" + _operacionEntity.eventoComprado.cantante + "[/]");
    //     Console.WriteLine("[bold #13D7F6]Localidad: [/][bold white]" + _operacionEntity.eventoComprado.localidad + "[/]");
    //     Console.WriteLine("[bold #13D7F6]Categoría: [/][bold white]" + _operacionEntity.eventoComprado.categoria + "[/]");
    //     Console.WriteLine("[bold #13D7F6]Fecha: [/][bold white]" + _operacionEntity.eventoComprado.fecha + "[/]");
    //     Console.WriteLine("[bold #13D7F6]Entradas compradas: [/][bold white]" + _operacionEntity.numEntradasCompradas + "[/]");
    //     Console.WriteLine("[bold #13D7F6]Precio total: [/][bold white]" + _operacionEntity.precioTotal + "[/]");
    //     Console.WriteLine("[bold #13D7F6]Fecha de compra: [/][bold white]" + _operacionEntity.fechaCompra + "[/]");
    //     Console.WriteLine(" ");
    // }
}

