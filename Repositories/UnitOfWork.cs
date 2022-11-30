using ApiSalud.DataAccess;
using ApiSalud.Entities;
using ApiSalud.Repositories.Interfaces;

namespace ApiSalud.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly SaludContext _dbContext;
    private IRepositoryBase<Product>? _productRepository;
    private IProductRepository _productWithDetails;


    public UnitOfWork(SaludContext dbContext)
    {
        _dbContext = dbContext;
    }


    public IRepositoryBase<Product> ProductRepository => _productRepository ?? new RepositoryBase<Product>(_dbContext);
    public IProductRepository ProductWithDetails => _productWithDetails ?? new ProductRepository(_dbContext);


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