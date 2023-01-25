using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1Vinneren.Storegp.Service.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Pk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Pk);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Pk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Pk);
                });

            migrationBuilder.CreateTable(
                name: "Subcategory",
                columns: table => new
                {
                    Pk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    PkCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategory", x => x.Pk);
                    table.ForeignKey(
                        name: "FK_Subcategory_Category_PkCategory",
                        column: x => x.PkCategory,
                        principalTable: "Category",
                        principalColumn: "Pk",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Pk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    NumMaterial = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PkSubCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Pk);
                    table.ForeignKey(
                        name: "FK_Product_Subcategory_PkSubCategory",
                        column: x => x.PkSubCategory,
                        principalTable: "Subcategory",
                        principalColumn: "Pk",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryProduct",
                columns: table => new
                {
                    Pk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Units = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PkInventory = table.Column<int>(type: "int", nullable: false),
                    PkProduct = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryProduct", x => x.Pk);
                    table.ForeignKey(
                        name: "FK_InventoryProduct_Inventory_PkInventory",
                        column: x => x.PkInventory,
                        principalTable: "Inventory",
                        principalColumn: "Pk",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryProduct_Product_PkProduct",
                        column: x => x.PkProduct,
                        principalTable: "Product",
                        principalColumn: "Pk",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryProduct_PkInventory",
                table: "InventoryProduct",
                column: "PkInventory");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryProduct_PkProduct",
                table: "InventoryProduct",
                column: "PkProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Product_PkSubCategory",
                table: "Product",
                column: "PkSubCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategory_PkCategory",
                table: "Subcategory",
                column: "PkCategory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryProduct");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Subcategory");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
