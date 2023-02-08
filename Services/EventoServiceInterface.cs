public interface EventoServiceInterface{
    // public void listarEventoExtendido();
    public List<EventoEntity> GetAll();
    public EventoEntity Get(int id);
    public void Add(EventoEntity evento);
     public void Delete(int id);
}