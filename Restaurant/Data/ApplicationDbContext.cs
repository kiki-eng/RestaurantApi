using Microsoft.EntityFrameworkCore;
using Restaurant.Entities;

namespace Restaurant.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
