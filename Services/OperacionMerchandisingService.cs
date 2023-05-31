using NyxellntAPI.Entities;
public class OperacionMerchandisingService : OperacionMerchandisingServiceInterface
{
    private readonly NyxellntDb _context;
    public OperacionMerchandisingService(NyxellntDb context)
    {
        _context = context;
    }

    public List<OperacionMerchandisingEntity> GetAll() => _context.OperacionesProductos.ToList();

    public OperacionMerchandisingEntity Get(int id) => _context.OperacionesProductos.ToList().FirstOrDefault(p => p.idOperacionMerchandising == id);

    public void Add(OperacionMerchandisingEntity operacionProductos)
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

    public void Update(OperacionMerchandisingEntity operacionProductosEntity)
    {
        _context.Update(operacionProductosEntity);
        _context.SaveChanges();
    }
}

