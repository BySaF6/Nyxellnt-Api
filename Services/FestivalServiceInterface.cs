public interface FestivalServiceInterface
{
    public List<FestivalEntity> GetAll();
    public FestivalEntity Get(int id);
    public void Add(FestivalEntity festival);
    public void Delete(int id);

    public void Update(FestivalEntity festivalEntity);
}