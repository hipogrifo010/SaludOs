using ApiSalud.DataAccess;
using ApiSalud.Entities;
using ApiSalud.Repositories.Interfaces;

namespace ApiSalud.Repositories;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(SaludContext context) : base(context)
    {
    }

    public async Task<(int totalPages, IEnumerable<Product> recordList)> GetProductPagingextra(int Id, int pageNumber,
        int pageSize)
    {
        var list = await Task.FromResult(_context.Set<Product>()
            .Where(t => t.Id == Id)
            .OrderBy(x => x.ProductName)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsEnumerable());
        var totalRecords = _context.Set<Product>()
            .Where(t => t.Id == Id)
            .Count();
        return ((int)Math.Ceiling(totalRecords / (double)pageSize), list);
    }
}