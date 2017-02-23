using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NationBuilder.Models
{
    public class NationBuilderDbContext : IdentityDbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Nation> Nations { get; set; }
        public DbSet<NationStructure> NationsStructures { get; set; }
        public DbSet<Structure> Structures { get; set; }
        public DbSet<Government> Governments { get; set; }
        public new DbSet<ApplicationUser> Users { get; set; }

        public NationBuilderDbContext()
        {
        }

        public NationBuilderDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=NationBuilder;integrated security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }

    }
}
