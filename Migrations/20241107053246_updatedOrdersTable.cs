using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsyaStore.Migrations
{
    /// <inheritdoc />
    public partial class updatedOrdersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ZIPCode",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "City",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "State",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "ZIPCode",
                table: "orders");
        }
    }
}
