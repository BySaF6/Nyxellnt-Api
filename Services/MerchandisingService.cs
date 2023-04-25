using NyxellntAPI.Entities;
public class MerchandisingService : MerchandisingServiceInterface
{
    private readonly NyxellntDb _context;
    public MerchandisingService(NyxellntDb context)
    {
        _context = context;
    }

    public List<MerchandisingEntity> GetAll()
    {
        return _context.Merchandising.ToList();
    }

    public MerchandisingEntity Get(int id)
    {
        return _context.Merchandising.ToList().FirstOrDefault(p => p.idMerchandising == id);
    }


    public void Add(MerchandisingEntity merchandising)
    {
        _context.Add(merchandising);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var merchandising = Get(id);
        if (merchandising is null)
            return;

        _context.Remove(merchandising);
        _context.SaveChanges();
    }

    public void Update(MerchandisingEntity merchandisingEntity)
    {
        _context.Update(merchandisingEntity);
        _context.SaveChanges();
    }
}
