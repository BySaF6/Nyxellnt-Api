public interface MerchandisingServiceInterface
{
    // public void listarFestivalExtendido();
    public List<MerchandisingEntity> GetAll();
    public MerchandisingEntity Get(int id);
    public void Add(MerchandisingEntity merchandising);
    public void Delete(int id);

    public void Update(MerchandisingEntity merchandisingEntity);
}