using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiSalud.Migrations
{
    /// <inheritdoc />
    public partial class migra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    DrugBrand = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Company = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    TypeOfMedication = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Company", "DrugBrand", "LastUpdate", "Price", "ProductName", "TypeOfMedication" },
                values: new object[] { 1, "Roemmers", "Amoxicilina", new DateTime(2000, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 800, "Amoxidal 500", "Tablet" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
