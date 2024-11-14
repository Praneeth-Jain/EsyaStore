using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsyaStore.Migrations
{
    /// <inheritdoc />
    public partial class AddedDiscount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalPrice",
                table: "products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OrderPrice",
                table: "orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "products");

            migrationBuilder.DropColumn(
                name: "FinalPrice",
                table: "products");

            migrationBuilder.DropColumn(
                name: "OrderPrice",
                table: "orders");
        }
    }
}
