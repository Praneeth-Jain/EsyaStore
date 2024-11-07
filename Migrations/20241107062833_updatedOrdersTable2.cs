using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsyaStore.Migrations
{
    /// <inheritdoc />
    public partial class updatedOrdersTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNo",
                table: "orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderNo",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
