using NyxellntAPI.Entities;
public class EventoService : EventoServiceInterface
{
    private readonly NyxellntDb _context;
    public EventoService(NyxellntDb context)
    {
        _context = context;
    }

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
        _context.Add(evento);
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

    public void Update(EventoEntity eventoEntity)
    {
        _context.Update(eventoEntity);
        _context.SaveChanges();
    }
}
