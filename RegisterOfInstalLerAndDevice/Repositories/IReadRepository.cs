using Microsoft.EntityFrameworkCore;
using RegisterOfInstalLerAndDevice.Entities;
namespace RegisterOfInstalLerAndDevice.Repositories;

public interface IReadRepository<out T> where T: class, IEntity
{
    public IEnumerable<T> GetAll();

    public T? GetByID(int id);

}
