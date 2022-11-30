using ApiSalud.DataAccess;
using ApiSalud.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiSalud.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly SaludContext _context;
    private readonly DbSet<T> _entities;

    public RepositoryBase(SaludContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await Task.FromResult(_entities.AsEnumerable());
    }

    public async Task<(int totalPages, IEnumerable<T> recordList)> GetAllPaging(int pageNumber, int pageSize)
    {
        var list = await Task.FromResult(_entities
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsEnumerable());
        var totalRecords = _entities.Count();
        return ((int)Math.Ceiling(totalRecords / (double)pageSize), list);
    }


    public async Task<T> GetById(int id)
    {
        return await _entities.FindAsync(id);
    }

    public async Task Insert(T entity)
    {
        _entities.Add(entity);
    }

    public async Task Update(T entity)
    {
        _entities.Update(entity);
    }

    public async Task Delete(int id)
    {
        var entity = await GetById(id);

        if (entity != null) _entities.Remove(entity);
    }
}