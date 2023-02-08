using NyxellntAPI.Entities;
public class EventoService : EventoServiceInterface
{
    private readonly NyxellntDb _context;
    public EventoService(NyxellntDb context)
    {
        _context = context;
    }

    // public static List<EventoEntity> Eventos { get; }
    // static int nextId = 6;

    public List<EventoEntity> GetAll()
    {
        return _context.Eventos.ToList();
    }

    public EventoEntity Get(int id)
    {
        return _context.Eventos.ToList().FirstOrDefault(p => p.idEvento == id);
    }


    public void Add(EventoEntity evento)
    {
        // evento.idEvento = nextId++;
        _context.Eventos.Add(evento);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var evento = Get(id);
        if (evento is null)
            return;

        _context.Remove(evento);
        _context.SaveChanges();
    }

    // public static void Update(EventoEntity evento)
    // {
    //     var index = Eventos.FindIndex(p => p.idEvento == evento.idEvento);
    //     if (index == -1)
    //         return;

    //     Eventos[index] = evento;
    // }

    // public void listarEventoExtendido()
    // {
    //     Console.WriteLine("[bold #13D7F6]EventoEntity: [/][bold white]" + _eventoEntity.nombre + "[/]");
    //     Console.WriteLine("[bold #13D7F6]Arista: [/][bold white]" + _eventoEntity.cantante + "[/]");
    //     Console.WriteLine("[bold #13D7F6]\nDescripción:[/]");
    //     Console.WriteLine("[bold white]" + _eventoEntity.descripcion + "[/]");
    //     Console.WriteLine("[bold #13D7F6]\nLocalidad: [/][bold white]" + _eventoEntity.localidad + "[/]");
    //     Console.WriteLine("[bold #13D7F6]Estilo: [/][bold white]" + _eventoEntity.categoria + "[/]");
    //     Console.WriteLine("[bold #13D7F6]Fecha: [/][bold white]" + _eventoEntity.fecha + "[/]");
    //     Console.WriteLine("[bold #13D7F6]Precio: [/][bold white]" + _eventoEntity.precioEntrada + " euros[/]");
    //     Console.WriteLine("[bold #13D7F6]Entradas restantes: [/][bold white]" + _eventoEntity.stock + "[/]");
    // }
    // public void listarEventoLinea()
    // {
    //     Console.WriteLine("[bold #13D7F6]" + _eventoEntity.idEvento + ".[/] [bold #13D7F6]Nombre: [/][bold white]" + _eventoEntity.nombre + ",[/] [bold #13D7F6]Cantante: [/][bold white]" + _eventoEntity.cantante + ",[/] [bold #13D7F6]Localidad: [/][bold white]" + _eventoEntity.localidad + ",[/] [bold #13D7F6]Categoría: [/][bold white]" + _eventoEntity.categoria + ",[/] [bold #13D7F6]Precio: [/][bold white]" + _eventoEntity.precioEntrada + " euros[/]");
    // }
}
