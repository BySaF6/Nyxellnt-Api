public interface OperacionServiceInterface{
    public List<OperacionEntity> GetAll();
    public OperacionEntity Get(int id);
    public void Add(OperacionEntity operacion);
    public void Delete(int id);
}