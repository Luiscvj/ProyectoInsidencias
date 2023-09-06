using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class Correccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_insidencia_trainer_UsuarioId",
                table: "insidencia");

            migrationBuilder.DropForeignKey(
                name: "FK_roles_usuario_trainer_UsuarioId",
                table: "roles_usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_sesion_uso_trainer_UsuariosId",
                table: "sesion_uso");

            migrationBuilder.DropForeignKey(
                name: "FK_trainer_arl_ArlId",
                table: "trainer");

            migrationBuilder.DropForeignKey(
                name: "FK_trainer_ciudad_CiudadId",
                table: "trainer");

            migrationBuilder.DropForeignKey(
                name: "FK_trainer_direccion_DireccionId",
                table: "trainer");

            migrationBuilder.DropForeignKey(
                name: "FK_trainer_eps_EpsId",
                table: "trainer");

            migrationBuilder.DropForeignKey(
                name: "FK_trainer_genero_GeneroId",
                table: "trainer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_trainer",
                table: "trainer");

            migrationBuilder.RenameTable(
                name: "trainer",
                newName: "usuario");

            migrationBuilder.RenameIndex(
                name: "IX_trainer_GeneroId",
                table: "usuario",
                newName: "IX_usuario_GeneroId");

            migrationBuilder.RenameIndex(
                name: "IX_trainer_EpsId",
                table: "usuario",
                newName: "IX_usuario_EpsId");

            migrationBuilder.RenameIndex(
                name: "IX_trainer_DireccionId",
                table: "usuario",
                newName: "IX_usuario_DireccionId");

            migrationBuilder.RenameIndex(
                name: "IX_trainer_CiudadId",
                table: "usuario",
                newName: "IX_usuario_CiudadId");

            migrationBuilder.RenameIndex(
                name: "IX_trainer_ArlId",
                table: "usuario",
                newName: "IX_usuario_ArlId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuario",
                table: "usuario",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_insidencia_usuario_UsuarioId",
                table: "insidencia",
                column: "UsuarioId",
                principalTable: "usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_roles_usuario_usuario_UsuarioId",
                table: "roles_usuario",
                column: "UsuarioId",
                principalTable: "usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sesion_uso_usuario_UsuariosId",
                table: "sesion_uso",
                column: "UsuariosId",
                principalTable: "usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_arl_ArlId",
                table: "usuario",
                column: "ArlId",
                principalTable: "arl",
                principalColumn: "ArlID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_ciudad_CiudadId",
                table: "usuario",
                column: "CiudadId",
                principalTable: "ciudad",
                principalColumn: "CiudadId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_direccion_DireccionId",
                table: "usuario",
                column: "DireccionId",
                principalTable: "direccion",
                principalColumn: "DireccionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_eps_EpsId",
                table: "usuario",
                column: "EpsId",
                principalTable: "eps",
                principalColumn: "EpsID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_genero_GeneroId",
                table: "usuario",
                column: "GeneroId",
                principalTable: "genero",
                principalColumn: "GeneroID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_insidencia_usuario_UsuarioId",
                table: "insidencia");

            migrationBuilder.DropForeignKey(
                name: "FK_roles_usuario_usuario_UsuarioId",
                table: "roles_usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_sesion_uso_usuario_UsuariosId",
                table: "sesion_uso");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_arl_ArlId",
                table: "usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_ciudad_CiudadId",
                table: "usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_direccion_DireccionId",
                table: "usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_eps_EpsId",
                table: "usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_genero_GeneroId",
                table: "usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuario",
                table: "usuario");

            migrationBuilder.RenameTable(
                name: "usuario",
                newName: "trainer");

            migrationBuilder.RenameIndex(
                name: "IX_usuario_GeneroId",
                table: "trainer",
                newName: "IX_trainer_GeneroId");

            migrationBuilder.RenameIndex(
                name: "IX_usuario_EpsId",
                table: "trainer",
                newName: "IX_trainer_EpsId");

            migrationBuilder.RenameIndex(
                name: "IX_usuario_DireccionId",
                table: "trainer",
                newName: "IX_trainer_DireccionId");

            migrationBuilder.RenameIndex(
                name: "IX_usuario_CiudadId",
                table: "trainer",
                newName: "IX_trainer_CiudadId");

            migrationBuilder.RenameIndex(
                name: "IX_usuario_ArlId",
                table: "trainer",
                newName: "IX_trainer_ArlId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_trainer",
                table: "trainer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_insidencia_trainer_UsuarioId",
                table: "insidencia",
                column: "UsuarioId",
                principalTable: "trainer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_roles_usuario_trainer_UsuarioId",
                table: "roles_usuario",
                column: "UsuarioId",
                principalTable: "trainer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sesion_uso_trainer_UsuariosId",
                table: "sesion_uso",
                column: "UsuariosId",
                principalTable: "trainer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trainer_arl_ArlId",
                table: "trainer",
                column: "ArlId",
                principalTable: "arl",
                principalColumn: "ArlID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trainer_ciudad_CiudadId",
                table: "trainer",
                column: "CiudadId",
                principalTable: "ciudad",
                principalColumn: "CiudadId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trainer_direccion_DireccionId",
                table: "trainer",
                column: "DireccionId",
                principalTable: "direccion",
                principalColumn: "DireccionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trainer_eps_EpsId",
                table: "trainer",
                column: "EpsId",
                principalTable: "eps",
                principalColumn: "EpsID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trainer_genero_GeneroId",
                table: "trainer",
                column: "GeneroId",
                principalTable: "genero",
                principalColumn: "GeneroID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
