public interface UsuarioServiceInterface{
    public List<UsuarioEntity> GetAll();
    public UsuarioEntity Get(int id);
    public void Add(UsuarioEntity usuario);
     public void Delete(int id);
    //  public void Update(UsuarioEntity usuario);
}