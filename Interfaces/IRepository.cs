namespace TuCarbureAPI.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Get();
        T? Get(int id);
        T insert(T entity);
    }
}
