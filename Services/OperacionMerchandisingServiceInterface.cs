public interface OperacionMerchandisingServiceInterface
{
    public List<OperacionMerchandisingEntity> GetAll();
    public OperacionMerchandisingEntity Get(int id);
    public void Add(OperacionMerchandisingEntity operacion);
    public void Delete(int id);

    public void Update(OperacionMerchandisingEntity operacionProductosEntity);
}