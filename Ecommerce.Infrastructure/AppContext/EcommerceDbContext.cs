using Ecommerce.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.AppContext
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Brand>
                (
                entity =>
                {
                    new Brand
                    {
                        Name = "Zara",
                        Id = Guid.NewGuid(),
                        AboutUs = "Commen famous brand",
                        FranchiseAssets = 87,
                        Portfolio = "Many barnd assests"
                    };
                    new Brand
                    {
                        Name = "H&M",
                        Id = Guid.NewGuid(),
                        AboutUs = "Global Franchise",
                        FranchiseAssets = 125,
                        Portfolio = "globally verious assests"
                    };
                }
                );
            modelBuilder.Entity<Category>
                (
                entity =>
                {
                    new Category
                    {
                        Name = "SummerCollection",
                        Id = Guid.NewGuid(),
                        Brief = "Fits the Summer style",
                        InternalSubCategory = 15,
                    };
                    new Category
                    {
                        Name = "WinterCollection",
                        Id = Guid.NewGuid(),
                        Brief = "Fits the Winter style",
                        InternalSubCategory = 12,
                    };
                }
                );
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
