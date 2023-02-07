public class OperacionService : OperacionServiceInterface
{
    private readonly OperacionEntity _operacionEntity;
    public OperacionService(OperacionEntity operacionEntity)
    {
        _operacionEntity = operacionEntity;
    }

    static List<OperacionEntity> Operaciones { get; }
    static int nextId = 1;

    public static List<OperacionEntity> GetAll() => Operaciones;

    public static OperacionEntity? Get(int id) => Operaciones.FirstOrDefault(p => p.idOperacion == id);

    public static void Add(OperacionEntity operacion)
    {
        operacion.idOperacion = nextId++;
        Operaciones.Add(operacion);
    }

    public static void Delete(int id)
    {
        var operacion = Get(id);
        if (operacion is null)
            return;

        Operaciones.Remove(operacion);
    }

    public static void Update(OperacionEntity operacion)
    {
        var index = Operaciones.FindIndex(p => p.idOperacion == operacion.idOperacion);
        if (index == -1)
            return;

        Operaciones[index] = operacion;
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

