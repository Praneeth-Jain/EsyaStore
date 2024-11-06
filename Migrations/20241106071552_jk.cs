using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsyaStore.Migrations
{
    /// <inheritdoc />
    public partial class jk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "sellers");

            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "sellers");

            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "sellers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "sellers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "sellers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "sellers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
