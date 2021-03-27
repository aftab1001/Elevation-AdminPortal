using Microsoft.EntityFrameworkCore.Migrations;

namespace Elevations.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description2",
                table: "Dashboard");

            migrationBuilder.AddColumn<long>(
                name: "Bath",
                table: "Rooms",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Bed",
                table: "Rooms",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Length",
                table: "Rooms",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Bath",
                table: "Dishes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Bed",
                table: "Dishes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Length",
                table: "Dishes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Bath",
                table: "Dashboard",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Bed",
                table: "Dashboard",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Length",
                table: "Dashboard",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Bath",
                table: "Apartments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Bed",
                table: "Apartments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Length",
                table: "Apartments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bath",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Bed",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Bath",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Bed",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Bath",
                table: "Dashboard");

            migrationBuilder.DropColumn(
                name: "Bed",
                table: "Dashboard");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Dashboard");

            migrationBuilder.DropColumn(
                name: "Bath",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "Bed",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Apartments");

            migrationBuilder.AddColumn<string>(
                name: "Description2",
                table: "Dashboard",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
