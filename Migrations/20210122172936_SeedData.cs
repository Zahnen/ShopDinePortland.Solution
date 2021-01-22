using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopDinePortland.Solution.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "Cuisine", "Name", "Neighborhood", "Service" },
                values: new object[,]
                {
                    { 1, "Mediterranean", "Tusk", "East Burnside", "Casual Dining" },
                    { 2, "Italian", "DeNicola's", "Southeast", "Casual Dining" },
                    { 3, "American", "PDX Sliders", "Sellwood", "Casual Dining" },
                    { 4, "Mexican", "Guero", "Laurelhurst", "Casual Dining" },
                    { 5, "Chinese", "Stretch The Noodle", "Downtown", "To-go" }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopId", "Name", "Neighborhood", "Type" },
                values: new object[,]
                {
                    { 1, "Frances May", "West End", "Clothing" },
                    { 2, "Machus", "East Burnside", "Clothing" },
                    { 3, "Hay", "Pearl", "Homegoods" },
                    { 4, "Stars Mall", "Sellwood", "Antiques" },
                    { 5, "Beam and Anchor", "Northeast", "Homegoods" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: 5);
        }
    }
}
