using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NyxellntAPI.Migrations
{
    /// <inheritdoc />
    public partial class NuevaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operaciones");

            migrationBuilder.AddColumn<decimal>(
                name: "precioEntradaVip",
                table: "Festivales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "stockVip",
                table: "Festivales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Merchandising",
                columns: table => new
                {
                    idMerchandising = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idFestival = table.Column<int>(type: "int", nullable: false),
                    tipoProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nombreProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precioProducto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    descripcionProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stockProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchandising", x => x.idMerchandising);
                });

            migrationBuilder.CreateTable(
                name: "OperacionesEntradas",
                columns: table => new
                {
                    idOperacionEntradas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idFestival = table.Column<int>(type: "int", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    numEntradasCompradas = table.Column<int>(type: "int", nullable: false),
                    precioTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fechaCompra = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperacionesEntradas", x => x.idOperacionEntradas);
                });

            migrationBuilder.CreateTable(
                name: "OperacionesProductos",
                columns: table => new
                {
                    idOperacionMerchandising = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idFestival = table.Column<int>(type: "int", nullable: false),
                    idMerchandising = table.Column<int>(type: "int", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    numProductosComprados = table.Column<int>(type: "int", nullable: false),
                    precioTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fechaCompra = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperacionesProductos", x => x.idOperacionMerchandising);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Merchandising");

            migrationBuilder.DropTable(
                name: "OperacionesEntradas");

            migrationBuilder.DropTable(
                name: "OperacionesProductos");

            migrationBuilder.DropColumn(
                name: "precioEntradaVip",
                table: "Festivales");

            migrationBuilder.DropColumn(
                name: "stockVip",
                table: "Festivales");

            migrationBuilder.CreateTable(
                name: "Operaciones",
                columns: table => new
                {
                    idOperacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaCompra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idFestival = table.Column<int>(type: "int", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    numEntradasCompradas = table.Column<int>(type: "int", nullable: false),
                    precioTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operaciones", x => x.idOperacion);
                });
        }
    }
}
