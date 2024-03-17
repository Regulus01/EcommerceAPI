using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Authentication.Migrations
{
    /// <inheritdoc />
    public partial class Update_Relacionamento_Usuario_Pessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Usu_Nome",
                schema: "Authentication",
                table: "Usuario");

            migrationBuilder.AddColumn<Guid>(
                name: "Pes_PessoaId",
                schema: "Authentication",
                table: "Usuario",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Pes_PessoaId",
                schema: "Authentication",
                table: "Usuario",
                column: "Pes_PessoaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Pessoa_Pes_PessoaId",
                schema: "Authentication",
                table: "Usuario",
                column: "Pes_PessoaId",
                principalSchema : "Administracao",
                principalTable: "Pessoa",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Pessoa_Pes_PessoaId",
                schema: "Authentication",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_Pes_PessoaId",
                schema: "Authentication",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Pes_PessoaId",
                schema: "Authentication",
                table: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "Usu_Nome",
                schema: "Authentication",
                table: "Usuario",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
