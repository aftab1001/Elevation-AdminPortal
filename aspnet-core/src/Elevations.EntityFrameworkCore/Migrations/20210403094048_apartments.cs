namespace Elevations.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class apartments : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("Image2", "Rooms");

            migrationBuilder.DropColumn("Image3", "Rooms");

            migrationBuilder.DropColumn("Image4", "Rooms");

            migrationBuilder.DropColumn("Image5", "Rooms");

            migrationBuilder.DropColumn("Image1", "Reservation");

            migrationBuilder.DropColumn("Image2", "Reservation");

            migrationBuilder.DropColumn("Image3", "Reservation");

            migrationBuilder.DropColumn("Image4", "Reservation");

            migrationBuilder.DropColumn("Image5", "Reservation");

            migrationBuilder.DropColumn("Image2", "Dishes");

            migrationBuilder.DropColumn("Image3", "Dishes");

            migrationBuilder.DropColumn("Image4", "Dishes");

            migrationBuilder.DropColumn("Image5", "Dishes");

            migrationBuilder.DropColumn("Image2", "Dashboard");

            migrationBuilder.DropColumn("Image3", "Dashboard");

            migrationBuilder.DropColumn("Image4", "Dashboard");

            migrationBuilder.DropColumn("Image5", "Dashboard");

            migrationBuilder.DropColumn("Image2", "Apartments");

            migrationBuilder.DropColumn("Image3", "Apartments");

            migrationBuilder.DropColumn("Image4", "Apartments");

            migrationBuilder.DropColumn("Image5", "Apartments");

            migrationBuilder.RenameColumn("Image1", "Rooms", "Image");

            migrationBuilder.RenameColumn("Image1", "Dishes", "Image");

            migrationBuilder.RenameColumn("Image1", "Dashboard", "Image");

            migrationBuilder.RenameColumn("Image1", "Apartments", "Image");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn("Image", "Rooms", "Image1");

            migrationBuilder.RenameColumn("Image", "Dishes", "Image1");

            migrationBuilder.RenameColumn("Image", "Dashboard", "Image1");

            migrationBuilder.RenameColumn("Image", "Apartments", "Image1");

            migrationBuilder.AddColumn<string>("Image2", "Rooms", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>("Image3", "Rooms", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>("Image4", "Rooms", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>("Image5", "Rooms", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>(
                "Image1",
                "Reservation",
                "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>("Image2", "Reservation", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>("Image3", "Reservation", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>("Image4", "Reservation", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>("Image5", "Reservation", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>("Image2", "Dishes", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>("Image3", "Dishes", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>("Image4", "Dishes", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>("Image5", "Dishes", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>("Image2", "Dashboard", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>("Image3", "Dashboard", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>("Image4", "Dashboard", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>("Image5", "Dashboard", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>("Image2", "Apartments", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>("Image3", "Apartments", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>("Image4", "Apartments", "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>("Image5", "Apartments", "nvarchar(max)", nullable: true);
        }
    }
}