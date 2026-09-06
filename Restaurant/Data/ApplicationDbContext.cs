using Microsoft.EntityFrameworkCore;
using Restaurant.Entities;

namespace Restaurant.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Food>()
                .HasOne(f => f.CreatedByUser)
                .WithMany()
                .HasForeignKey(f => f.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Food>()
                .HasOne(f => f.UpdatedByUser)
                .WithMany()
                .HasForeignKey(f => f.UpdatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Food>()
                .HasOne(f => f.DeletedByUser)
                .WithMany()
                .HasForeignKey(f => f.DeletedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}