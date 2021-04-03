using Microsoft.EntityFrameworkCore.Migrations;

namespace Elevations.Migrations
{
    public partial class apartments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Rooms",
                newName: "Image1");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Dishes",
                newName: "Image1");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Dashboard",
                newName: "Image1");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Apartments",
                newName: "Image1");

            migrationBuilder.AddColumn<string>(
                name: "Image2",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image3",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image4",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image5",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image1",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image2",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image3",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image4",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image5",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image2",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image3",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image4",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image5",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image2",
                table: "Dashboard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image3",
                table: "Dashboard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image4",
                table: "Dashboard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image5",
                table: "Dashboard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image2",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image3",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image4",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image5",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image2",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Image3",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Image4",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Image5",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Image1",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "Image2",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "Image3",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "Image4",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "Image5",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "Image2",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Image3",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Image4",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Image5",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Image2",
                table: "Dashboard");

            migrationBuilder.DropColumn(
                name: "Image3",
                table: "Dashboard");

            migrationBuilder.DropColumn(
                name: "Image4",
                table: "Dashboard");

            migrationBuilder.DropColumn(
                name: "Image5",
                table: "Dashboard");

            migrationBuilder.DropColumn(
                name: "Image2",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "Image3",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "Image4",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "Image5",
                table: "Apartments");

            migrationBuilder.RenameColumn(
                name: "Image1",
                table: "Rooms",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Image1",
                table: "Dishes",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Image1",
                table: "Dashboard",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Image1",
                table: "Apartments",
                newName: "Image");
        }
    }
}
