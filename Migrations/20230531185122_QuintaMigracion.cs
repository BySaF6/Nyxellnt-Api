using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NyxellntAPI.Migrations
{
    /// <inheritdoc />
    public partial class QuintaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Festivales",
                table: "Festivales");

            migrationBuilder.RenameTable(
                name: "Festivales",
                newName: "Eventos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Eventos",
                table: "Eventos",
                column: "idFestival");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Eventos",
                table: "Eventos");

            migrationBuilder.RenameTable(
                name: "Eventos",
                newName: "Festivales");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Festivales",
                table: "Festivales",
                column: "idFestival");
        }
    }
}
