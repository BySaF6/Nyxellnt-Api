public class OperacionService : OperacionServiceInterface
{
    private readonly OperacionEntity _operacionEntity;
    public OperacionService(OperacionEntity operacionEntity)
    {
        _operacionEntity = operacionEntity;
    }
    public void mostrarOperacion()
    {
        Console.WriteLine("[bold #13D7F6]Id de la operación: [/][bold white]" + _operacionEntity.idOperacion + "[/]");
        Console.WriteLine("[bold #13D7F6]Nombre: [/][bold white]" + _operacionEntity.eventoComprado.nombre + "[/]");
        Console.WriteLine("[bold #13D7F6]Cantante: [/][bold white]" + _operacionEntity.eventoComprado.cantante + "[/]");
        Console.WriteLine("[bold #13D7F6]Localidad: [/][bold white]" + _operacionEntity.eventoComprado.localidad + "[/]");
        Console.WriteLine("[bold #13D7F6]Categoría: [/][bold white]" + _operacionEntity.eventoComprado.categoria + "[/]");
        Console.WriteLine("[bold #13D7F6]Fecha: [/][bold white]" + _operacionEntity.eventoComprado.fecha + "[/]");
        Console.WriteLine("[bold #13D7F6]Entradas compradas: [/][bold white]" + _operacionEntity.numEntradasCompradas + "[/]");
        Console.WriteLine("[bold #13D7F6]Precio total: [/][bold white]" + _operacionEntity.precioTotal + "[/]");
        Console.WriteLine("[bold #13D7F6]Fecha de compra: [/][bold white]" + _operacionEntity.fechaCompra + "[/]");
        Console.WriteLine(" ");
    }
}

