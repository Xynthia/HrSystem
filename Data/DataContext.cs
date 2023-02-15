using Microsoft.EntityFrameworkCore;

namespace HRSystem.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> User => Set<User>();
        public DbSet<Declaratie> Declaratie => Set<Declaratie>();
        public DbSet<Vakantie> Vakantie => Set<Vakantie>();
    }
}
