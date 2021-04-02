using Microsoft.EntityFrameworkCore.Migrations;

namespace Elevations.Migrations
{
    public partial class news : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "News",
                newName: "Image1");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "News",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Description1",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description2",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description3",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description4",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description5",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image2",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image3",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image4",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image5",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description1",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Description2",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Description3",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Description4",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Description5",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Image2",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Image3",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Image4",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Image5",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "News",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Image1",
                table: "News",
                newName: "Image");
        }
    }
}
