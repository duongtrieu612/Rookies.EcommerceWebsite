using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoLuong",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "Hinh",
                table: "Product",
                newName: "Image");

            migrationBuilder.AddColumn<double>(
                name: "Gia",
                table: "Product",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gia",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Product",
                newName: "Hinh");

            migrationBuilder.AddColumn<int>(
                name: "SoLuong",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
