namespace SistemaLojaDeRoupas.Repository
{
    public interface IRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Add(T entity);
    }
}
