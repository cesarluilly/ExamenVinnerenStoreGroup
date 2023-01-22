using Microsoft.EntityFrameworkCore;
using Vinneren.Storegp.Domain.Entity;

//                                                          //AUTHOR:  (CLGA - Cesar Garcia).
//                                                          //CO-AUTHOR:  (-).
//                                                          //DATE: January 22, 2022. 
namespace Vinneren.Storegp.Infraescructure.Data
{
    //==================================================================================================================
    public class VinnContext : DbContext
    {
        public DbSet<ProductEntity> Product { get; set; }
        public DbSet<CategoryEntity> Category { get; set; }
        public DbSet<InventoryEntity> Inventory { get; set; }
        public DbSet<InventoryProductEntity> InventoryProduct { get; set; }
        public DbSet<SubcategoryEntity> Subcategory { get; set; }
        public VinnContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder
            )
        {
            //                                              //Inventory
            modelBuilder.Entity<InventoryProductEntity>()
                .HasOne(a => a.Inventory).WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InventoryProductEntity>()
                .HasOne(a => a.Product).WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}