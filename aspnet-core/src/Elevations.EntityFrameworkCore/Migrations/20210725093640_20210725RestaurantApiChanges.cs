using Microsoft.EntityFrameworkCore.Migrations;

namespace Elevations.Migrations
{
    public partial class _20210725RestaurantApiChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bath",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Bed",
                table: "Dishes");

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
                name: "ImageSequence",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "Image1",
                table: "Dishes",
                newName: "Image");

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

            migrationBuilder.AddColumn<int>(
                name: "PaymentDetails",
                table: "Booking",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_PaymentDetails",
                table: "Booking",
                column: "PaymentDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_PaymentDetails_PaymentDetails",
                table: "Booking",
                column: "PaymentDetails",
                principalTable: "PaymentDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_PaymentDetails_PaymentDetails",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_PaymentDetails",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "IsPopular",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "IsPoster",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "PaymentDetails",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Dishes",
                newName: "Image1");

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

            migrationBuilder.AddColumn<int>(
                name: "ImageSequence",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "Length",
                table: "Dishes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
