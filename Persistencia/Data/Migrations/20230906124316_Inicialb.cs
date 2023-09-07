using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicialb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_insidencia_Persona_PersonaId",
                table: "insidencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_arl_ArlId",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_ciudad_CiudadId",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_direccion_DireccionId",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_eps_EpsId",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_genero_GeneroId",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_sesion_uso_Persona_PersonaId",
                table: "sesion_uso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persona",
                table: "Persona");

            migrationBuilder.RenameTable(
                name: "Persona",
                newName: "persona");

            migrationBuilder.RenameIndex(
                name: "IX_Persona_GeneroId",
                table: "persona",
                newName: "IX_persona_GeneroId");

            migrationBuilder.RenameIndex(
                name: "IX_Persona_EpsId",
                table: "persona",
                newName: "IX_persona_EpsId");

            migrationBuilder.RenameIndex(
                name: "IX_Persona_DireccionId",
                table: "persona",
                newName: "IX_persona_DireccionId");

            migrationBuilder.RenameIndex(
                name: "IX_Persona_CiudadId",
                table: "persona",
                newName: "IX_persona_CiudadId");

            migrationBuilder.RenameIndex(
                name: "IX_Persona_ArlId",
                table: "persona",
                newName: "IX_persona_ArlId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "persona",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_persona",
                table: "persona",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_insidencia_persona_PersonaId",
                table: "insidencia",
                column: "PersonaId",
                principalTable: "persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_persona_arl_ArlId",
                table: "persona",
                column: "ArlId",
                principalTable: "arl",
                principalColumn: "ArlID");

            migrationBuilder.AddForeignKey(
                name: "FK_persona_ciudad_CiudadId",
                table: "persona",
                column: "CiudadId",
                principalTable: "ciudad",
                principalColumn: "CiudadId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_persona_direccion_DireccionId",
                table: "persona",
                column: "DireccionId",
                principalTable: "direccion",
                principalColumn: "DireccionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_persona_eps_EpsId",
                table: "persona",
                column: "EpsId",
                principalTable: "eps",
                principalColumn: "EpsID");

            migrationBuilder.AddForeignKey(
                name: "FK_persona_genero_GeneroId",
                table: "persona",
                column: "GeneroId",
                principalTable: "genero",
                principalColumn: "GeneroID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_persona_usuario_Id",
                table: "persona",
                column: "Id",
                principalTable: "usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sesion_uso_persona_PersonaId",
                table: "sesion_uso",
                column: "PersonaId",
                principalTable: "persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_insidencia_persona_PersonaId",
                table: "insidencia");

            migrationBuilder.DropForeignKey(
                name: "FK_persona_arl_ArlId",
                table: "persona");

            migrationBuilder.DropForeignKey(
                name: "FK_persona_ciudad_CiudadId",
                table: "persona");

            migrationBuilder.DropForeignKey(
                name: "FK_persona_direccion_DireccionId",
                table: "persona");

            migrationBuilder.DropForeignKey(
                name: "FK_persona_eps_EpsId",
                table: "persona");

            migrationBuilder.DropForeignKey(
                name: "FK_persona_genero_GeneroId",
                table: "persona");

            migrationBuilder.DropForeignKey(
                name: "FK_persona_usuario_Id",
                table: "persona");

            migrationBuilder.DropForeignKey(
                name: "FK_sesion_uso_persona_PersonaId",
                table: "sesion_uso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_persona",
                table: "persona");

            migrationBuilder.RenameTable(
                name: "persona",
                newName: "Persona");

            migrationBuilder.RenameIndex(
                name: "IX_persona_GeneroId",
                table: "Persona",
                newName: "IX_Persona_GeneroId");

            migrationBuilder.RenameIndex(
                name: "IX_persona_EpsId",
                table: "Persona",
                newName: "IX_Persona_EpsId");

            migrationBuilder.RenameIndex(
                name: "IX_persona_DireccionId",
                table: "Persona",
                newName: "IX_Persona_DireccionId");

            migrationBuilder.RenameIndex(
                name: "IX_persona_CiudadId",
                table: "Persona",
                newName: "IX_Persona_CiudadId");

            migrationBuilder.RenameIndex(
                name: "IX_persona_ArlId",
                table: "Persona",
                newName: "IX_Persona_ArlId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Persona",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persona",
                table: "Persona",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_insidencia_Persona_PersonaId",
                table: "insidencia",
                column: "PersonaId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_arl_ArlId",
                table: "Persona",
                column: "ArlId",
                principalTable: "arl",
                principalColumn: "ArlID");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_ciudad_CiudadId",
                table: "Persona",
                column: "CiudadId",
                principalTable: "ciudad",
                principalColumn: "CiudadId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_direccion_DireccionId",
                table: "Persona",
                column: "DireccionId",
                principalTable: "direccion",
                principalColumn: "DireccionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_eps_EpsId",
                table: "Persona",
                column: "EpsId",
                principalTable: "eps",
                principalColumn: "EpsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_genero_GeneroId",
                table: "Persona",
                column: "GeneroId",
                principalTable: "genero",
                principalColumn: "GeneroID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sesion_uso_Persona_PersonaId",
                table: "sesion_uso",
                column: "PersonaId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
