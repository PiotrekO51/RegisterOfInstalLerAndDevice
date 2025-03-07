namespace RegisterOfInstalLerAndDevice.Repositories;
using Microsoft.EntityFrameworkCore;
using RegisterOfInstalLerAndDevice.Entities;

public delegate void ItemAdded<in T>(object item);
public class SqlRepositories<T> where T : class, IEntity, new()
{
    private readonly DbSet<T> _dbSet;
    private readonly DbContext _dbContext;
    private event ItemAdded<T> ItemAddedCallBack;  

    public SqlRepositories(DbContext context, ItemAdded<T> itemAddedCallback = null )
    {
        _dbContext = context;
        _dbSet = _dbContext.Set<T>();
        ItemAddedCallBack = itemAddedCallback;
    }

    public event EventHandler<T> ItemAdded;
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
        ItemAdded?.Invoke(this, item);
        ItemAddedCallBack?.Invoke(item);
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
