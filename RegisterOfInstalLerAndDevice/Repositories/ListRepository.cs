using Microsoft.EntityFrameworkCore;
using RegisterOfInstalLerAndDevice.Entities;

namespace RegisterOfInstalLerAndDevice.Repositories;

public class ListRepository<T> where T : class, IEntity, new()
{
    protected readonly List<T> _items = new();

    public void Add(T item)
    {
        item.Id = _items.Count + 1;
        _items.Add(item);
    }

    public IEnumerable<T> GetAll() => _items.ToList();


    public T GetById(int id)
    {
        return _items.Single(item => item.Id == id);

    }

    public void Remove(T item)
    {
        _items.Remove(item);
    }
    public void Save()
    {
        foreach (var item in _items)
        {
            Console.WriteLine(item);
        }
    }
}
