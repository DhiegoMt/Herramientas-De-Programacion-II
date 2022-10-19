using Microsoft.EntityFrameworkCore.Migrations;

namespace api_autores.Migrations
{
    public partial class Libro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    codigoautor = table.Column<int>(type: "int", nullable: false),
                    autorcodigo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.codigo);
                    table.ForeignKey(
                        name: "FK_Libro_Autor_autorcodigo",
                        column: x => x.autorcodigo,
                        principalTable: "Autor",
                        principalColumn: "codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libro_autorcodigo",
                table: "Libro",
                column: "autorcodigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libro");
        }
    }
}
