using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NyxellntAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    idEvento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cantante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    localidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precioEntrada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    categoria = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.idEvento);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.idUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Operaciones",
                columns: table => new
                {
                    idOperacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eventoCompradoidEvento = table.Column<int>(type: "int", nullable: true),
                    numEntradasCompradas = table.Column<int>(type: "int", nullable: false),
                    precioTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fechaCompra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioEntityidUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operaciones", x => x.idOperacion);
                    table.ForeignKey(
                        name: "FK_Operaciones_Eventos_eventoCompradoidEvento",
                        column: x => x.eventoCompradoidEvento,
                        principalTable: "Eventos",
                        principalColumn: "idEvento");
                    table.ForeignKey(
                        name: "FK_Operaciones_Usuarios_UsuarioEntityidUsuario",
                        column: x => x.UsuarioEntityidUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operaciones_eventoCompradoidEvento",
                table: "Operaciones",
                column: "eventoCompradoidEvento");

            migrationBuilder.CreateIndex(
                name: "IX_Operaciones_UsuarioEntityidUsuario",
                table: "Operaciones",
                column: "UsuarioEntityidUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operaciones");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
