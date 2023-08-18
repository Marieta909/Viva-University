using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstEntity.Migrations
{
    /// <inheritdoc />
    public partial class AddedTimestampCust : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "Customers",
                type: "rowversion",
                rowVersion: true,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Customers");
        }
    }
}
