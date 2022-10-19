using Microsoft.EntityFrameworkCore.Migrations;

namespace api_autores.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Autor_autorcodigoautor",
                table: "Libro");

            migrationBuilder.DropColumn(
                name: "codigoautor",
                table: "Libro");

            migrationBuilder.AlterColumn<string>(
                name: "titulo",
                table: "Libro",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "autorcodigoautor",
                table: "Libro",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "estado",
                table: "Libro",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Autor_autorcodigoautor",
                table: "Libro",
                column: "autorcodigoautor",
                principalTable: "Autor",
                principalColumn: "codigoautor",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Autor_autorcodigoautor",
                table: "Libro");

            migrationBuilder.DropColumn(
                name: "estado",
                table: "Libro");

            migrationBuilder.AlterColumn<int>(
                name: "titulo",
                table: "Libro",
                type: "int",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "autorcodigoautor",
                table: "Libro",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "codigoautor",
                table: "Libro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Autor_autorcodigoautor",
                table: "Libro",
                column: "autorcodigoautor",
                principalTable: "Autor",
                principalColumn: "codigoautor",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
