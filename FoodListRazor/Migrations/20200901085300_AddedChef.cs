using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodListRazor.Migrations
{
    public partial class AddedChef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Foods");

            migrationBuilder.AddColumn<string>(
                name: "Chef",
                table: "Foods",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chef",
                table: "Foods");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
