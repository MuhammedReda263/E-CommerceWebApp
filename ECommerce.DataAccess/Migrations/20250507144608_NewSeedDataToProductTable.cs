using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NewSeedDataToProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 51, "Ava Winters", 1, "An intriguing tale that spans centuries.", "FOT000000051", "", 90.0, 85.0, 70.0, 80.0, "Echoes of Time" },
                    { 52, "Liam Frost", 2, "A story of love and mystery.", "FOT000000052", "", 85.0, 80.0, 65.0, 75.0, "Whispers in the Rain" },
                    { 53, "Chloe River", 3, "Darkness hides secrets in the woods.", "FOT000000053", "", 70.0, 65.0, 50.0, 60.0, "Mystic Shadows" },
                    { 54, "Noah Bright", 2, "A hero rises when all hope fades.", "FOT000000054", "", 75.0, 70.0, 55.0, 65.0, "Winds of Fate" },
                    { 55, "Isla Dawn", 1, "Adventures in a world of ice and light.", "FOT000000055", "", 95.0, 90.0, 75.0, 85.0, "Crystal Horizon" },
                    { 56, "Jack Orion", 3, "When the sea speaks, only few can listen.", "FOT000000056", "", 60.0, 55.0, 45.0, 50.0, "The Silent Sea" },
                    { 57, "Nora Vale", 2, "At the boundary of light and dark, truths are revealed.", "FOT000000057", "", 78.0, 73.0, 58.0, 68.0, "Twilight's Edge" },
                    { 58, "Leo Hart", 1, "The world must burn before it can rise.", "FOT000000058", "", 88.0, 83.0, 68.0, 78.0, "Fire and Ashes" },
                    { 59, "Zara Phoenix", 3, "Illusions are sometimes more real than the truth.", "FOT000000059", "", 66.0, 61.0, 46.0, 56.0, "Moonlight Mirage" },
                    { 60, "Mason Quinn", 2, "A journey long abandoned is rediscovered.", "FOT000000060", "", 72.0, 67.0, 52.0, 62.0, "The Forgotten Path" },
                    { 61, "Ella Bloom", 1, "Love and fate under a vast sky.", "FOT000000061", "", 100.0, 95.0, 80.0, 90.0, "Beneath the Stars" },
                    { 62, "Henry Vale", 2, "Nature’s fury awakens ancient powers.", "FOT000000062", "", 83.0, 78.0, 63.0, 73.0, "Storm's Call" },
                    { 63, "Maya Thorn", 3, "Every flower hides a secret story.", "FOT000000063", "", 74.0, 69.0, 54.0, 64.0, "Garden of Secrets" },
                    { 64, "Owen Reed", 2, "The world above is not what it seems.", "FOT000000064", "", 69.0, 64.0, 49.0, 59.0, "Ashen Skies" },
                    { 65, "Sophie Blaze", 1, "A dying flame can spark a revolution.", "FOT000000065", "", 92.0, 87.0, 72.0, 82.0, "The Final Ember" },
                    { 66, "Jasper Hale", 3, "Two realities, one shattered mirror.", "FOT000000066", "", 86.0, 81.0, 66.0, 76.0, "Mirror of Worlds" },
                    { 67, "Aria Frost", 1, "Cold lands hide warm hearts.", "FOT000000067", "", 77.0, 72.0, 57.0, 67.0, "Veil of Ice" },
                    { 68, "Eli Stone", 2, "Time weaves destinies in strange ways.", "FOT000000068", "", 84.0, 79.0, 64.0, 74.0, "Threads of Time" },
                    { 69, "Luna Ray", 3, "A desert of secrets and songs.", "FOT000000069", "", 73.0, 68.0, 53.0, 63.0, "Song of the Sands" },
                    { 70, "Kai Ember", 1, "Hope rises with the sun.", "FOT000000070", "", 82.0, 77.0, 62.0, 72.0, "Legacy of Dawn" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70);
        }
    }
}
