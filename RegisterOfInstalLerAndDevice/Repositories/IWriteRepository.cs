using Microsoft.EntityFrameworkCore;
using RegisterOfInstalLerAndDevice.Entities;

namespace RegisterOfInstalLerAndDevice.Repositories;

public  interface IWriteRepository<in T> where T : class, IEntity
{
    void Add(T item);
    public void Save();
    void Remove(T item);
}
