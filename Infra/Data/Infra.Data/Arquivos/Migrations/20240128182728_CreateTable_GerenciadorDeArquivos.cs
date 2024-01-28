using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Arquivos.Migrations
{
    /// <inheritdoc />
    public partial class CreateTable_GerenciadorDeArquivos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Arquivos");

            migrationBuilder.CreateTable(
                name: "GerenciadorDeArquivos",
                schema: "Arquivos",
                columns: table => new
                {
                    Ger_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Ger_EntidadeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Ger_Entidade = table.Column<string>(type: "text", nullable: false),
                    Ger_Caminho = table.Column<string>(type: "text", nullable: false),
                    Ger_Ordem = table.Column<int>(type: "integer", nullable: false),
                    Ger_ContentType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GerenciadorDeArquivos", x => x.Ger_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GerenciadorDeArquivos",
                schema: "Arquivos");
        }
    }
}
