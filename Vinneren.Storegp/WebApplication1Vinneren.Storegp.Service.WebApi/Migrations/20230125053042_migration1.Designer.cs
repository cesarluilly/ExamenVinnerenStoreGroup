// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vinneren.Storegp.Infraescructure.Data;

#nullable disable

namespace WebApplication1Vinneren.Storegp.Service.WebApi.Migrations
{
    [DbContext(typeof(VinnContext))]
    [Migration("20230125053042_migration1")]
    partial class migration1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Vinneren.Storegp.Domain.Entity.CategoryEntity", b =>
                {
                    b.Property<int>("Pk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pk"));

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.HasKey("Pk");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Vinneren.Storegp.Domain.Entity.InventoryEntity", b =>
                {
                    b.Property<int>("Pk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pk"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Note");

                    b.HasKey("Pk");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("Vinneren.Storegp.Domain.Entity.InventoryProductEntity", b =>
                {
                    b.Property<int>("Pk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pk"));

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Note");

                    b.Property<int>("PkInventory")
                        .HasColumnType("int");

                    b.Property<int>("PkProduct")
                        .HasColumnType("int");

                    b.Property<int>("Units")
                        .HasColumnType("int");

                    b.HasKey("Pk");

                    b.HasIndex("PkInventory");

                    b.HasIndex("PkProduct");

                    b.ToTable("InventoryProduct");
                });

            modelBuilder.Entity("Vinneren.Storegp.Domain.Entity.ProductEntity", b =>
                {
                    b.Property<int>("Pk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pk"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.Property<string>("NumMaterial")
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NumMaterial");

                    b.Property<int>("PkSubCategory")
                        .HasColumnType("int");

                    b.HasKey("Pk");

                    b.HasIndex("PkSubCategory");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Vinneren.Storegp.Domain.Entity.SubcategoryEntity", b =>
                {
                    b.Property<int>("Pk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pk"));

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.Property<int>("PkCategory")
                        .HasColumnType("int");

                    b.HasKey("Pk");

                    b.HasIndex("PkCategory");

                    b.ToTable("Subcategory");
                });

            modelBuilder.Entity("Vinneren.Storegp.Domain.Entity.InventoryProductEntity", b =>
                {
                    b.HasOne("Vinneren.Storegp.Domain.Entity.InventoryEntity", "Inventory")
                        .WithMany()
                        .HasForeignKey("PkInventory")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Vinneren.Storegp.Domain.Entity.ProductEntity", "Product")
                        .WithMany()
                        .HasForeignKey("PkProduct")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Inventory");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Vinneren.Storegp.Domain.Entity.ProductEntity", b =>
                {
                    b.HasOne("Vinneren.Storegp.Domain.Entity.SubcategoryEntity", "Subcategory")
                        .WithMany()
                        .HasForeignKey("PkSubCategory")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Subcategory");
                });

            modelBuilder.Entity("Vinneren.Storegp.Domain.Entity.SubcategoryEntity", b =>
                {
                    b.HasOne("Vinneren.Storegp.Domain.Entity.CategoryEntity", "Category")
                        .WithMany()
                        .HasForeignKey("PkCategory")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
