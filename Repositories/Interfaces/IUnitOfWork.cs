namespace ApiSalud.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IProductRepository ProductRepository { get; }
    int SaveChanges();
    Task<int> SaveChangesAsync();
}