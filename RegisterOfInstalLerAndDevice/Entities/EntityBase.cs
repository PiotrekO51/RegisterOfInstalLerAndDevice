
namespace RegisterOfInstalLerAndDevice.Entities;

public abstract class EntityBase : IEntity
{
    public  int Id { get; set; }
    
    public string CompanyName { get; set; }
}
