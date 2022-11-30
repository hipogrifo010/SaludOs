using ApiSalud.Core.Models.DTO;
using ApiSalud.Entities;

namespace ApiSalud.Core.Interfaces;

public interface IProductService
{
    Task<bool> DeleteProduct(int id);
    Task<bool> UpdateDeposit(int id, ProductDto productDto);
    Task InsertProduct(ProductDto productDto);
    Task<(int totalPages, IEnumerable<Product> recordList)> GetProductsPagingdos(int pageNumber, int pageSize);

    Task<IEnumerable<Product>> GetProducts();
}