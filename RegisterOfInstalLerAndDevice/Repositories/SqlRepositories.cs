namespace RegisterOfInstalLerAndDevice.Repositories;
using Microsoft.EntityFrameworkCore;
using RegisterOfInstalLerAndDevice.Entities;

public class SqlRepositories<T> where T : class, IEntity, new()
{
    private readonly DbSet<T> _dbSet;
    private readonly DbContext _dbContext;

    public SqlRepositories(DbContext context)
    {
        _dbContext = context;
        _dbSet = _dbContext.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }
    public T? GetById(int id)
    {
        return _dbSet.Single(item => item.Id == id);
    }
    public void Add (T item)
    {
        _dbSet.Add(item);   
    }
    public void Save()
    {
        _dbContext.SaveChanges();
    }
    public void Remove(T item)
    {
        _dbSet.Remove(item);
    }
}
