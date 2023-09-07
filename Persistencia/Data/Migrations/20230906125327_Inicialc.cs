using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicialc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_persona_usuario_Id",
                table: "persona");

            migrationBuilder.AddColumn<int>(
                name: "usuarioDePersona",
                table: "usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "persona",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_usuarioDePersona",
                table: "usuario",
                column: "usuarioDePersona",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_persona_usuarioDePersona",
                table: "usuario",
                column: "usuarioDePersona",
                principalTable: "persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuario_persona_usuarioDePersona",
                table: "usuario");

            migrationBuilder.DropIndex(
                name: "IX_usuario_usuarioDePersona",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "usuarioDePersona",
                table: "usuario");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "persona",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_persona_usuario_Id",
                table: "persona",
                column: "Id",
                principalTable: "usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
