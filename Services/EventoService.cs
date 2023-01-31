public class EventoService : EventoServiceInterface
{
    private readonly EventoEntity _eventoEntity;
    public EventoService(EventoEntity eventoEntity)
    {
        _eventoEntity = eventoEntity;
    }
    public void listarEventoExtendido()
    {
        Console.WriteLine("[bold #13D7F6]Evento: [/][bold white]" + _eventoEntity.nombre + "[/]");
        Console.WriteLine("[bold #13D7F6]Arista: [/][bold white]" + _eventoEntity.cantante + "[/]");
        Console.WriteLine("[bold #13D7F6]\nDescripción:[/]");
        Console.WriteLine("[bold white]" + _eventoEntity.descripcion + "[/]");
        Console.WriteLine("[bold #13D7F6]\nLocalidad: [/][bold white]" + _eventoEntity.localidad + "[/]");
        Console.WriteLine("[bold #13D7F6]Estilo: [/][bold white]" + _eventoEntity.categoria + "[/]");
        Console.WriteLine("[bold #13D7F6]Fecha: [/][bold white]" + _eventoEntity.fecha + "[/]");
        Console.WriteLine("[bold #13D7F6]Precio: [/][bold white]" + _eventoEntity.precioEntrada + " euros[/]");
        Console.WriteLine("[bold #13D7F6]Entradas restantes: [/][bold white]" + _eventoEntity.stock + "[/]");
    }
    public void listarEventoLinea()
    {
        Console.WriteLine("[bold #13D7F6]" + _eventoEntity.idEvento + ".[/] [bold #13D7F6]Nombre: [/][bold white]" + _eventoEntity.nombre + ",[/] [bold #13D7F6]Cantante: [/][bold white]" + _eventoEntity.cantante + ",[/] [bold #13D7F6]Localidad: [/][bold white]" + _eventoEntity.localidad + ",[/] [bold #13D7F6]Categoría: [/][bold white]" + _eventoEntity.categoria + ",[/] [bold #13D7F6]Precio: [/][bold white]" + _eventoEntity.precioEntrada + " euros[/]");
    }
}
