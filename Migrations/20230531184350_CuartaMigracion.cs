using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NyxellntAPI.Migrations
{
    /// <inheritdoc />
    public partial class CuartaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "precioTotal",
                table: "OperacionesProductos",
                newName: "precioTotalProductos");

            migrationBuilder.RenameColumn(
                name: "precioTotal",
                table: "OperacionesEntradas",
                newName: "precioTotalEntradas");

            migrationBuilder.AddColumn<byte[]>(
                name: "imagen",
                table: "Usuarios",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "numEntradasVipCompradas",
                table: "OperacionesEntradas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "imagen",
                table: "Merchandising",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "imagen",
                table: "Festivales",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imagen",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "numEntradasVipCompradas",
                table: "OperacionesEntradas");

            migrationBuilder.DropColumn(
                name: "imagen",
                table: "Merchandising");

            migrationBuilder.DropColumn(
                name: "imagen",
                table: "Festivales");

            migrationBuilder.RenameColumn(
                name: "precioTotalProductos",
                table: "OperacionesProductos",
                newName: "precioTotal");

            migrationBuilder.RenameColumn(
                name: "precioTotalEntradas",
                table: "OperacionesEntradas",
                newName: "precioTotal");
        }
    }
}
