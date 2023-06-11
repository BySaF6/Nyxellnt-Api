using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NyxellntAPI.Migrations
{
    /// <inheritdoc />
    public partial class SextaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Festivales",
                table: "Festivales");

            migrationBuilder.RenameTable(
                name: "Festivales",
                newName: "Festivales");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Festivales",
                table: "Festivales",
                column: "idFestival");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Festivales",
                table: "Festivales");

            migrationBuilder.RenameTable(
                name: "Festivales",
                newName: "Festivales");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Festivales",
                table: "Festivales",
                column: "idFestival");
        }
    }
}
