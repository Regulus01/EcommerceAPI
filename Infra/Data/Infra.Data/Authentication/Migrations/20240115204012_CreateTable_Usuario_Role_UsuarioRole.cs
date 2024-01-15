using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Authentication.Migrations
{
    /// <inheritdoc />
    public partial class CreateTable_Usuario_Role_UsuarioRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Authentication");

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "Authentication",
                columns: table => new
                {
                    Rol_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Rol_Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Rol_Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "Authentication",
                columns: table => new
                {
                    Usu_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Usu_Nome = table.Column<string>(type: "text", nullable: false),
                    Usu_Email = table.Column<string>(type: "text", nullable: false),
                    Usu_Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Usu_Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRole",
                schema: "Authentication",
                columns: table => new
                {
                    UsR_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Usu_UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    Rol_RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRole", x => x.UsR_Id);
                    table.ForeignKey(
                        name: "FK_UsuarioRole_Role_Rol_RoleId",
                        column: x => x.Rol_RoleId,
                        principalSchema: "Authentication",
                        principalTable: "Role",
                        principalColumn: "Rol_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioRole_Usuario_Usu_UsuarioId",
                        column: x => x.Usu_UsuarioId,
                        principalSchema: "Authentication",
                        principalTable: "Usuario",
                        principalColumn: "Usu_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRole_Rol_RoleId",
                schema: "Authentication",
                table: "UsuarioRole",
                column: "Rol_RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRole_Usu_UsuarioId",
                schema: "Authentication",
                table: "UsuarioRole",
                column: "Usu_UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioRole",
                schema: "Authentication");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Authentication");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "Authentication");
        }
    }
}
