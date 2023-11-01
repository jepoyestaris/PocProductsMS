using Microsoft.EntityFrameworkCore;
using PocProductsMS.Model;

namespace PocProductsMS.Data
{
    public class EmwDbContext : DbContext
    {
        public EmwDbContext(DbContextOptions<EmwDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(e => e.Companies)
                .WithOne(e => e.Product)
                .HasForeignKey(e => e.ProductId)
                .IsRequired();
        }
    }
}
