using Microsoft.EntityFrameworkCore;

namespace latihan.api;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<Users> Users => Set<Users>();
}
