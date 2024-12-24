using Laptops.Model;
using Microsoft.EntityFrameworkCore;

namespace Laptops.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options) { }
        public DbSet<Laptop> Laptop { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<Ram> Ram { get; set; }
        public DbSet<Storage> storages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
