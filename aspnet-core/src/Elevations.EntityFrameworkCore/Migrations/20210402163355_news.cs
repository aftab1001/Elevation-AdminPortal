namespace Elevations.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class news : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("Description1", "News");

            migrationBuilder.DropColumn("Description2", "News");

            migrationBuilder.DropColumn("Description3", "News");

            migrationBuilder.DropColumn("Description4", "News");

            migrationBuilder.DropColumn("Description5", "News");

            migrationBuilder.DropColumn("Image2", "News");

            migrationBuilder.DropColumn("Image3", "News");

            migrationBuilder.DropColumn("Image4", "News");

            migrationBuilder.DropColumn("Image5", "News");

            migrationBuilder.RenameColumn("Name", "News", "Description");

            migrationBuilder.RenameColumn("Image1", "News", "Image");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn("Image", "News", "Image1");

            migrationBuilder.RenameColumn("Description", "News", "Name");

            migrationBuilder.AddColumn<string>("Description1", "News", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>("Description2", "News", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>("Description3", "News", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>("Description4", "News", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>("Description5", "News", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>("Image2", "News", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>("Image3", "News", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>("Image4", "News", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>("Image5", "News", "nvarchar(max)", nullable: true);
        }
    }
}