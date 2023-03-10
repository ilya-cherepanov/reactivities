using domain;
using Microsoft.EntityFrameworkCore;

namespace persistence;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Activity> Activities => Set<Activity>();
}
