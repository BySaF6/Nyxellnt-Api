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
                name: "FK_Operaciones_Eventos_eventoCompradoidEvento",
                table: "Operaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Operaciones_Usuarios_UsuarioEntityidUsuario",
                table: "Operaciones");

            migrationBuilder.DropIndex(
                name: "IX_Operaciones_eventoCompradoidEvento",
                table: "Operaciones");

            migrationBuilder.DropIndex(
                name: "IX_Operaciones_UsuarioEntityidUsuario",
                table: "Operaciones");

            migrationBuilder.DropColumn(
                name: "UsuarioEntityidUsuario",
                table: "Operaciones");

            migrationBuilder.DropColumn(
                name: "eventoCompradoidEvento",
                table: "Operaciones");

            migrationBuilder.AddColumn<string>(
                name: "idEvento",
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
                name: "idEvento",
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
                name: "eventoCompradoidEvento",
                table: "Operaciones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Operaciones_eventoCompradoidEvento",
                table: "Operaciones",
                column: "eventoCompradoidEvento");

            migrationBuilder.CreateIndex(
                name: "IX_Operaciones_UsuarioEntityidUsuario",
                table: "Operaciones",
                column: "UsuarioEntityidUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Operaciones_Eventos_eventoCompradoidEvento",
                table: "Operaciones",
                column: "eventoCompradoidEvento",
                principalTable: "Eventos",
                principalColumn: "idEvento");

            migrationBuilder.AddForeignKey(
                name: "FK_Operaciones_Usuarios_UsuarioEntityidUsuario",
                table: "Operaciones",
                column: "UsuarioEntityidUsuario",
                principalTable: "Usuarios",
                principalColumn: "idUsuario");
        }
    }
}
