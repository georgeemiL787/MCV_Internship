using Microsoft.EntityFrameworkCore;
using taskapp.Models;

namespace taskapp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Employee entity
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Salary).IsRequired();
            });
        }
    }
} 