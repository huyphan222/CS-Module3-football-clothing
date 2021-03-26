using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Migrations
{
    public partial class addProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 1, "Premier League" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 2, "SeriA" });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Discount", "Name", "OrigialPrice", "Photo", "Size" },
                values: new object[] { 1, 1, null, 0, "Ao Chelsea 2020-2021", 220000L, "~/images/AoChelsea2020.jpg", "M,L,XL" });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Discount", "Name", "OrigialPrice", "Photo", "Size" },
                values: new object[] { 2, 1, null, 0, "Ao Chelsea 2020-2021", 220000L, "~/images/AoChelsea2020.jpg", "M,L,XL" });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Discount", "Name", "OrigialPrice", "Photo", "Size" },
                values: new object[] { 3, 1, null, 0, "Ao Chelsea 2020-2021", 220000L, "~/images/AoChelsea2020.jpg", "M,L,XL" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "CategoryId",
                keyValue: 1);
        }
    }
}
