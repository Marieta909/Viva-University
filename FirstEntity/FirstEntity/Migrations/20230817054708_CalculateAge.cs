using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstEntity.Migrations
{
    /// <inheritdoc />
    public partial class CalculateAge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
           CREATE FUNCTION CalculateAge1
            (
                @birthdate DATETIME
            )
            RETURNS INT
            AS
            BEGIN
                DECLARE @age INT
                SET @age = DATEDIFF(YEAR, @birthdate, GETDATE()) -
                           IIF(DATEADD(YEAR, DATEDIFF(YEAR, @birthdate, GETDATE()), @birthdate) > GETDATE(), 1, 0)
                RETURN @age
            END
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION [dbo].[CalculateAge1]");
        }
    }
}
