using Jewelery.Models;
using Microsoft.EntityFrameworkCore;

namespace JeweleryShop.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WearingType>().HasData(
                new WearingType { Id = 1, Type = "Neklace" });

            modelBuilder.Entity<WearingType>().HasData(
                new WearingType { Id = 2, Type = "Ring" });

            modelBuilder.Entity<WearingType>().HasData(
                new WearingType { Id = 3, Type = "Earrings" });


            modelBuilder.Entity<Material>().HasData(
                new Material { Id = 1, Type = "Gold" });

            modelBuilder.Entity<Material>().HasData(
                new Material { Id = 2, Type = "Platinum" });


            modelBuilder.Entity<Stone>().HasData(
                new Stone { Id = 1, Type = "None" });
            modelBuilder.Entity<Stone>().HasData(
                new Stone { Id = 2, Type = "Diamond" });



            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Golden Neklace",
                    Description = "Fine Craftsmansship",
                    Price = 350,
                    MaterialsId = 1,
                    StonesId = 1,
                    TypeId = 1,
                    Size = "300x300",
                    ImageURl = "<URL GOES HERE>"

                });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 2,
                    Name = "Golden Ring",
                    Description = "Fine Craftsmansship",
                    Price = 100,
                    MaterialsId = 1,
                    StonesId = 1,
                    TypeId = 2,
                    Size = "300x300",
                    ImageURl = "<URL GOES HERE>"

                });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 3,
                    Name = "Platinum Ring with Diamond",
                    Description = "Fine Craftsmansship",
                    Price = 100,
                    MaterialsId = 2,
                    StonesId = 2,
                    TypeId = 2,
                    Size = "300x300",
                    ImageURl = "<URL GOES HERE>"

                });
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Stone> Stones { get; set; }
        public DbSet<WearingType> WearingTypes { get; set; }

    }
}
