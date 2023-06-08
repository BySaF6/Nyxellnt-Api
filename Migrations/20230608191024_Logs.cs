using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NyxellntAPI.Migrations
{
    /// <inheritdoc />
    public partial class Logs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idFestival",
                table: "Merchandising");

            migrationBuilder.AddColumn<string>(
                name: "nombreFestival",
                table: "Merchandising",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nombreFestival",
                table: "Merchandising");

            migrationBuilder.AddColumn<int>(
                name: "idFestival",
                table: "Merchandising",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
