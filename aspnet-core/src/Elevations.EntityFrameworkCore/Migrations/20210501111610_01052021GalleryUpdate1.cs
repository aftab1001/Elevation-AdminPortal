using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Elevations.Migrations
{
    public partial class _01052021GalleryUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gallery_ImageType_ImageType",
                table: "Gallery");

            migrationBuilder.DropTable(
                name: "ImageType");

            migrationBuilder.DropIndex(
                name: "IX_Gallery_ImageType",
                table: "Gallery");

            migrationBuilder.AlterColumn<string>(
                name: "ImageType",
                table: "Gallery",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ImageType",
                table: "Gallery",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ImageType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gallery_ImageType",
                table: "Gallery",
                column: "ImageType");

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_ImageType_ImageType",
                table: "Gallery",
                column: "ImageType",
                principalTable: "ImageType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
