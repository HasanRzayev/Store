using Microsoft.EntityFrameworkCore;
using Store.Models.Entities;
using System.Text.RegularExpressions;

namespace Store.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Mark> Marks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(s => s.Mark)
                .WithMany(g => g.Products)
                .HasForeignKey(s => s.mark_id);
        }

    }
}
