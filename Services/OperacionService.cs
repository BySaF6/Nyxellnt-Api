using NyxellntAPI.Entities;
public class OperacionService : OperacionServiceInterface
{
    private readonly NyxellntDb _context;
    public OperacionService(NyxellntDb context)
    {
        _context = context;
    }

    public List<OperacionEntity> GetAll() => _context.Operaciones.ToList();

    public OperacionEntity Get(int id) => _context.Operaciones.ToList().FirstOrDefault(p => p.idOperacion == id);

    public void Add(OperacionEntity operacion)
    {
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
}

