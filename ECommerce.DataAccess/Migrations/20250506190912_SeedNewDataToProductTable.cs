using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedNewDataToProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 101, "Billy Spark", 1, "Praesent vitae sodales libero...", "SWD9999001", "", 99.0, 92.0, 80.0, 85.0, "Fortune of Time" },
                    { 102, "Nancy Hoover", 3, "Praesent vitae sodales libero...", "CAW777777701", "", 40.0, 30.0, 20.0, 29.0, "Dark Skies" },
                    { 103, "Julian Button", 2, "Praesent vitae sodales libero...", "RITO5555501", "", 55.0, 50.0, 35.0, 48.0, "Vanish in the Sunset" },
                    { 104, "Abby Muscles", 1, "Praesent vitae sodales libero...", "WS3333333301", "", 70.0, 65.0, 53.0, 60.0, "Cotton Candy" },
                    { 105, "Ron Parker", 2, "Praesent vitae sodales libero...", "SOTJ1111111101", "", 60.0, 55.0, 55.0, 50.0, "Rock in the Ocean" },
                    { 106, "Laura Phantom", 3, "Praesent vitae sodales libero...", "FOT000000001", "", 80.0, 75.0, 55.0, 70.0, "Leaves and Wonders" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Billy Spark", 1, "Praesent vitae sodales libero...", "SWD9999001", "", 99.0, 90.0, 80.0, 85.0, "Fortune of Time" },
                    { 2, "Nancy Hoover", 3, "Praesent vitae sodales libero...", "CAW777777701", "", 40.0, 30.0, 20.0, 25.0, "Dark Skies" },
                    { 3, "Julian Button", 2, "Praesent vitae sodales libero...", "RITO5555501", "", 55.0, 50.0, 35.0, 40.0, "Vanish in the Sunset" },
                    { 4, "Abby Muscles", 1, "Praesent vitae sodales libero...", "WS3333333301", "", 70.0, 65.0, 55.0, 60.0, "Cotton Candy" },
                    { 5, "Ron Parker", 2, "Praesent vitae sodales libero...", "SOTJ1111111101", "", 60.0, 55.0, 45.0, 50.0, "Rock in the Ocean" },
                    { 6, "Laura Phantom", 3, "Praesent vitae sodales libero...", "FOT000000001", "", 80.0, 75.0, 65.0, 70.0, "Leaves and Wonders" }
                });
        }
    }
}
