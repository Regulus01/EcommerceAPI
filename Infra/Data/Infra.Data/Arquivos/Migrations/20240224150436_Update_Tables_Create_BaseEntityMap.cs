using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Arquivos.Migrations
{
    /// <inheritdoc />
    public partial class Update_Tables_Create_BaseEntityMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ger_Id",
                schema: "Arquivos",
                table: "GerenciadorDeArquivos",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Ger_Caminho",
                schema: "Arquivos",
                table: "GerenciadorDeArquivos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CriadoEm",
                schema: "Arquivos",
                table: "GerenciadorDeArquivos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: DateTimeOffset.UtcNow);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModificadoEm",
                schema: "Arquivos",
                table: "GerenciadorDeArquivos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: DateTimeOffset.UtcNow);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CriadoEm",
                schema: "Arquivos",
                table: "GerenciadorDeArquivos");

            migrationBuilder.DropColumn(
                name: "ModificadoEm",
                schema: "Arquivos",
                table: "GerenciadorDeArquivos");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Arquivos",
                table: "GerenciadorDeArquivos",
                newName: "Ger_Id");

            migrationBuilder.AlterColumn<string>(
                name: "Ger_Caminho",
                schema: "Arquivos",
                table: "GerenciadorDeArquivos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
