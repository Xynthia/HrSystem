using Microsoft.EntityFrameworkCore;

namespace HRSystem.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Declaratie> Declaraties => Set<Declaratie>();
        public DbSet<Vakantie> Vakanties => Set<Vakantie>();
    }
}
