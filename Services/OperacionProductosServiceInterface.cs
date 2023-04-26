public interface OperacionProductosServiceInterface
{
    public List<OperacionProductosEntity> GetAll();
    public OperacionProductosEntity Get(int id);
    public void Add(OperacionProductosEntity operacion);
    public void Delete(int id);

    public void Update(OperacionProductosEntity operacionProductosEntity);
}