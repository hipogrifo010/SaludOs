using ApiSalud.Entities;

namespace ApiSalud.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepositoryBase<Product> ProductRepository { get; }
    IProductRepository ProductWithDetails { get; }
    int SaveChanges();
    Task<int> SaveChangesAsync();
}