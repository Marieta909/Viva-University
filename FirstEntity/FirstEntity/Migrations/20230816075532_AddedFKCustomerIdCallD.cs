using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstEntity.Migrations
{
    /// <inheritdoc />
    public partial class AddedFKCustomerIdCallD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "CallDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerAge",
                columns: table => new
                {
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_CallDetails_CustomerId",
                table: "CallDetails",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CallDetails_Customers_CustomerId",
                table: "CallDetails",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CallDetails_Customers_CustomerId",
                table: "CallDetails");

            migrationBuilder.DropTable(
                name: "CustomerAge");

            migrationBuilder.DropIndex(
                name: "IX_CallDetails_CustomerId",
                table: "CallDetails");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CallDetails");
        }
    }
}
