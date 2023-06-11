using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NyxellntAPI.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operaciones_Festivales_festivalCompradoidFestival",
                table: "Operaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Operaciones_Usuarios_UsuarioEntityidUsuario",
                table: "Operaciones");

            migrationBuilder.DropIndex(
                name: "IX_Operaciones_festivalCompradoidFestival",
                table: "Operaciones");

            migrationBuilder.DropIndex(
                name: "IX_Operaciones_UsuarioEntityidUsuario",
                table: "Operaciones");

            migrationBuilder.DropColumn(
                name: "UsuarioEntityidUsuario",
                table: "Operaciones");

            migrationBuilder.DropColumn(
                name: "festivalCompradoidFestival",
                table: "Operaciones");

            migrationBuilder.AddColumn<string>(
                name: "idFestival",
                table: "Operaciones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "idUsuario",
                table: "Operaciones",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idFestival",
                table: "Operaciones");

            migrationBuilder.DropColumn(
                name: "idUsuario",
                table: "Operaciones");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioEntityidUsuario",
                table: "Operaciones",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "festivalCompradoidFestival",
                table: "Operaciones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Operaciones_festivalCompradoidFestival",
                table: "Operaciones",
                column: "festivalCompradoidFestival");

            migrationBuilder.CreateIndex(
                name: "IX_Operaciones_UsuarioEntityidUsuario",
                table: "Operaciones",
                column: "UsuarioEntityidUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Operaciones_Festivales_festivalCompradoidFestival",
                table: "Operaciones",
                column: "festivalCompradoidFestival",
                principalTable: "Festivales",
                principalColumn: "idFestival");

            migrationBuilder.AddForeignKey(
                name: "FK_Operaciones_Usuarios_UsuarioEntityidUsuario",
                table: "Operaciones",
                column: "UsuarioEntityidUsuario",
                principalTable: "Usuarios",
                principalColumn: "idUsuario");
        }
    }
}
