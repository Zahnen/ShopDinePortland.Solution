using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopDinePortland.Solution.Migrations
{
    public partial class MoreSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "Cuisine", "Name", "Neighborhood", "Service" },
                values: new object[,]
                {
                    { 6, "Korean", "Han Oak", "Downtown", "Casual Dining" },
                    { 7, "Scandanavian", "Maurice", "Downtown", "Casual Dining" }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopId", "Name", "Neighborhood", "Type" },
                values: new object[,]
                {
                    { 6, "Spartan Shop", "Southeast", "Homegoods" },
                    { 7, "Woonwinkel", "West End", "Homegoods" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: 7);
        }
    }
}
