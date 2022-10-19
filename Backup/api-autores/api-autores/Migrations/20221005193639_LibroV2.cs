using Microsoft.EntityFrameworkCore.Migrations;

namespace api_autores.Migrations
{
    public partial class LibroV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Autor_autorcodigo",
                table: "Libro");

            migrationBuilder.RenameColumn(
                name: "autorcodigo",
                table: "Libro",
                newName: "autorcodigoautor");

            migrationBuilder.RenameColumn(
                name: "codigo",
                table: "Libro",
                newName: "codigolibro");

            migrationBuilder.RenameIndex(
                name: "IX_Libro_autorcodigo",
                table: "Libro",
                newName: "IX_Libro_autorcodigoautor");

            migrationBuilder.RenameColumn(
                name: "codigo",
                table: "Autor",
                newName: "codigoautor");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Autor_autorcodigoautor",
                table: "Libro",
                column: "autorcodigoautor",
                principalTable: "Autor",
                principalColumn: "codigoautor",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Autor_autorcodigoautor",
                table: "Libro");

            migrationBuilder.RenameColumn(
                name: "autorcodigoautor",
                table: "Libro",
                newName: "autorcodigo");

            migrationBuilder.RenameColumn(
                name: "codigolibro",
                table: "Libro",
                newName: "codigo");

            migrationBuilder.RenameIndex(
                name: "IX_Libro_autorcodigoautor",
                table: "Libro",
                newName: "IX_Libro_autorcodigo");

            migrationBuilder.RenameColumn(
                name: "codigoautor",
                table: "Autor",
                newName: "codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Autor_autorcodigo",
                table: "Libro",
                column: "autorcodigo",
                principalTable: "Autor",
                principalColumn: "codigo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
