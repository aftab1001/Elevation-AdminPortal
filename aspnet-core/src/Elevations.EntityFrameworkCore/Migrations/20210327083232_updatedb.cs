namespace Elevations.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class updatedb : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("Bath", "Rooms");

            migrationBuilder.DropColumn("Bed", "Rooms");

            migrationBuilder.DropColumn("Length", "Rooms");

            migrationBuilder.DropColumn("Bath", "Dishes");

            migrationBuilder.DropColumn("Bed", "Dishes");

            migrationBuilder.DropColumn("Length", "Dishes");

            migrationBuilder.DropColumn("Bath", "Dashboard");

            migrationBuilder.DropColumn("Bed", "Dashboard");

            migrationBuilder.DropColumn("Length", "Dashboard");

            migrationBuilder.DropColumn("Bath", "Apartments");

            migrationBuilder.DropColumn("Bed", "Apartments");

            migrationBuilder.DropColumn("Length", "Apartments");

            migrationBuilder.AddColumn<string>("Description2", "Dashboard", "nvarchar(max)", nullable: true);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("Description2", "Dashboard");

            migrationBuilder.AddColumn<long>("Bath", "Rooms", "bigint", nullable: false, defaultValue: 0L);

            migrationBuilder.AddColumn<long>("Bed", "Rooms", "bigint", nullable: false, defaultValue: 0L);

            migrationBuilder.AddColumn<long>("Length", "Rooms", "bigint", nullable: false, defaultValue: 0L);

            migrationBuilder.AddColumn<long>("Bath", "Dishes", "bigint", nullable: false, defaultValue: 0L);

            migrationBuilder.AddColumn<long>("Bed", "Dishes", "bigint", nullable: false, defaultValue: 0L);

            migrationBuilder.AddColumn<long>("Length", "Dishes", "bigint", nullable: false, defaultValue: 0L);

            migrationBuilder.AddColumn<long>("Bath", "Dashboard", "bigint", nullable: false, defaultValue: 0L);

            migrationBuilder.AddColumn<long>("Bed", "Dashboard", "bigint", nullable: false, defaultValue: 0L);

            migrationBuilder.AddColumn<long>("Length", "Dashboard", "bigint", nullable: false, defaultValue: 0L);

            migrationBuilder.AddColumn<long>("Bath", "Apartments", "bigint", nullable: false, defaultValue: 0L);

            migrationBuilder.AddColumn<long>("Bed", "Apartments", "bigint", nullable: false, defaultValue: 0L);

            migrationBuilder.AddColumn<long>("Length", "Apartments", "bigint", nullable: false, defaultValue: 0L);
        }
    }
}