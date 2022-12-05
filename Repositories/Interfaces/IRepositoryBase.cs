namespace ApiSalud.Repositories.Interfaces;

public interface IRepositoryBase<T> where T : class
{
    Task<(int totalPages, IEnumerable<T> recordList)> GetAllPaging(int pageNumber, int pageSize);
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task Insert(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}