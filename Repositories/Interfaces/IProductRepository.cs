using ApiSalud.Entities;

namespace ApiSalud.Repositories.Interfaces;

public interface IProductRepository : IRepositoryBase<Product>
{
    Task<IEnumerable<Product>> GetAll();

    Task<(int totalPages, IEnumerable<Product> recordList)> GetProductPagingextra(int userId, int pageNumber,
        int pageSize);
}