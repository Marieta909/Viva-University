using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstEntity.Migrations
{
    /// <inheritdoc />
    public partial class addednewtableCallDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CallDetails",
                columns: table => new
                {
                    CallID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CallerNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CallDuration = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallDetails", x => x.CallID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallDetails");
        }
    }
}
