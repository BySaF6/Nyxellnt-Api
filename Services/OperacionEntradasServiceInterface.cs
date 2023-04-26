public interface OperacionEntradasServiceInterface
{
    public List<OperacionEntradasEntity> GetAll();
    public OperacionEntradasEntity Get(int id);
    public void Add(OperacionEntradasEntity operacion);
    public void Delete(int id);

    public void Update(OperacionEntradasEntity operacionEntradasEntity);
}