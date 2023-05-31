using NyxellntAPI.Entities;
public class FestivalService : FestivalServiceInterface
{
    private readonly NyxellntDb _context;
    public FestivalService(NyxellntDb context)
    {
        _context = context;
    }

    public List<FestivalEntity> GetAll()
    {
        return _context.Festivales.ToList();
    }

    public FestivalEntity Get(int id)
    {
        return _context.Festivales.ToList().FirstOrDefault(p => p.idFestival == id);
    }


    public void Add(FestivalEntity festival)
    {
        _context.Add(festival);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var festival = Get(id);
        if (festival is null)
            return;

        _context.Remove(festival);
        _context.SaveChanges();
    }

    public void Update(FestivalEntity festivalEntity)
    {
        _context.Update(festivalEntity);
        _context.SaveChanges();
    }
}
