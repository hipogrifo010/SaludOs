using ApiSalud.DataAccess;
using ApiSalud.Repositories.Interfaces;

namespace ApiSalud.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly SaludContext _dbContext;

    private IProductRepository _productWithDetails;


    public UnitOfWork(SaludContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IProductRepository ProductRepository
    {
        get { return _productWithDetails = _productWithDetails ?? new ProductRepository(_dbContext); }
    }


    public void Dispose()
    {
        _dbContext.Dispose();
        GC.SuppressFinalize(this);
    }

    public int SaveChanges()
    {
        return _dbContext.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}