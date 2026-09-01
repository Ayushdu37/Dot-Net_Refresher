using Microsoft.EntityFrameworkCore;
using Question2_CrudApp_DatabaseFirst.Models;

namespace Question2_CrudApp_DatabaseFirst.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("StudentCrudDb");
            }
        }
    }
}
