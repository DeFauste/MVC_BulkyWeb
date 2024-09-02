using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        { 

        }

        public DbSet<Categoty> Categoties { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoty>().HasData(
                new Categoty { Id = 1, Name = "Action1", DisplayOrder = 1 },
                new Categoty { Id = 2, Name = "Action2", DisplayOrder = 2 },
                new Categoty { Id = 3, Name = "Action3", DisplayOrder = 3 },
                new Categoty { Id = 4, Name = "Action4", DisplayOrder = 4 }
                );
            //base.OnModelCreating(modelBuilder);
        }
    }
}
