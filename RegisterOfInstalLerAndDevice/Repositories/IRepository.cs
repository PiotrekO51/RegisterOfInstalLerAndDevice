using Microsoft.EntityFrameworkCore;
using RegisterOfInstalLerAndDevice.Entities;

namespace RegisterOfInstalLerAndDevice.Repositories;

public interface IRepository<T>: IReadRepository<T>, IWriteRepository<T> 
    where T : class, IEntity
{
}