using Microsoft.EntityFrameworkCore.Migrations;

namespace Elevations.Migrations
{
    public partial class _20210725RestaurantApiChanges1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPopular",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "IsPoster",
                table: "Dishes");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Dishes");

            migrationBuilder.AddColumn<bool>(
                name: "IsPopular",
                table: "Dishes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPoster",
                table: "Dishes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
