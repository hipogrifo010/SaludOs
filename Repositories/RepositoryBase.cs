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
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}