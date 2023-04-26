using NyxellntAPI.Entities;
public class OperacionProductosService : OperacionProductosServiceInterface
{
    private readonly NyxellntDb _context;
    public OperacionProductosService(NyxellntDb context)
    {
        _context = context;
    }

    public List<OperacionProductosEntity> GetAll() => _context.OperacionesProductos.ToList();

    public OperacionProductosEntity Get(int id) => _context.OperacionesProductos.ToList().FirstOrDefault(p => p.idOperacionProductos == id);

    public void Add(OperacionProductosEntity operacionProductos)
    {
        _context.Add(operacionProductos);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var operacionProductos = Get(id);
        if (operacionProductos is null)
            return;

        _context.Remove(operacionProductos);
        _context.SaveChanges();
    }

    public void Update(OperacionProductosEntity operacionProductosEntity)
    {
        _context.Update(operacionProductosEntity);
        _context.SaveChanges();
    }
}

