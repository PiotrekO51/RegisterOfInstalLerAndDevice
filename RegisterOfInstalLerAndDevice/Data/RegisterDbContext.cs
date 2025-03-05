using Microsoft.EntityFrameworkCore;
using RegisterOfInstalLerAndDevice.Entities;

namespace RegisterOfInstalLerAndDevice.Data;
public  class RegisterDbContext: DbContext
{
    public DbSet<Device> Devices => Set<Device>();
    public DbSet<Installer> Installers => Set<Installer>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase("StorageRegister");
    }
}
