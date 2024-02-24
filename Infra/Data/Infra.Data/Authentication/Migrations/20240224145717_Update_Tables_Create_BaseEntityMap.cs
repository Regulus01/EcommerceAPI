using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Authentication.Migrations
{
    /// <inheritdoc />
    public partial class Update_Tables_Create_BaseEntityMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsR_Id",
                schema: "Authentication",
                table: "UsuarioRole",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Usu_Id",
                schema: "Authentication",
                table: "Usuario",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Rol_Id",
                schema: "Authentication",
                table: "Role",
                newName: "Id");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CriadoEm",
                schema: "Authentication",
                table: "UsuarioRole",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: DateTimeOffset.UtcNow);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModificadoEm",
                schema: "Authentication",
                table: "UsuarioRole",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: DateTimeOffset.UtcNow);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CriadoEm",
                schema: "Authentication",
                table: "Usuario",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: DateTimeOffset.UtcNow);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModificadoEm",
                schema: "Authentication",
                table: "Usuario",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: DateTimeOffset.UtcNow);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CriadoEm",
                schema: "Authentication",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: DateTimeOffset.UtcNow);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModificadoEm",
                schema: "Authentication",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: DateTimeOffset.UtcNow);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CriadoEm",
                schema: "Authentication",
                table: "UsuarioRole");

            migrationBuilder.DropColumn(
                name: "ModificadoEm",
                schema: "Authentication",
                table: "UsuarioRole");

            migrationBuilder.DropColumn(
                name: "CriadoEm",
                schema: "Authentication",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "ModificadoEm",
                schema: "Authentication",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "CriadoEm",
                schema: "Authentication",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "ModificadoEm",
                schema: "Authentication",
                table: "Role");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Authentication",
                table: "UsuarioRole",
                newName: "UsR_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Authentication",
                table: "Usuario",
                newName: "Usu_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Authentication",
                table: "Role",
                newName: "Rol_Id");
        }
    }
}
