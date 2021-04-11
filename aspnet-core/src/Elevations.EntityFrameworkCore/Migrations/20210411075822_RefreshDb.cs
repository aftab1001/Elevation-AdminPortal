using Microsoft.EntityFrameworkCore.Migrations;

namespace Elevations.Migrations
{
    public partial class RefreshDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "Rooms",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "Apartments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Apartments");
        }
    }
}
