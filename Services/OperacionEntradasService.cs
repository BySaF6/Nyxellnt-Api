using NyxellntAPI.Entities;
public class OperacionEntradasService : OperacionEntradasServiceInterface
{
    private readonly NyxellntDb _context;
    public OperacionEntradasService(NyxellntDb context)
    {
        _context = context;
    }

    public List<OperacionEntradasEntity> GetAll() => _context.OperacionesEntradas.ToList();

    public OperacionEntradasEntity Get(int id) => _context.OperacionesEntradas.ToList().FirstOrDefault(p => p.idOperacionEntradas == id);

    public void Add(OperacionEntradasEntity operacionEntradas)
    {
        _context.Add(operacionEntradas);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var operacionEntradas = Get(id);
        if (operacionEntradas is null)
            return;

        _context.Remove(operacionEntradas);
        _context.SaveChanges();
    }

    public void Update(OperacionEntradasEntity operacionEntradasEntity)
    {
        _context.Update(operacionEntradasEntity);
        _context.SaveChanges();
    }
}

