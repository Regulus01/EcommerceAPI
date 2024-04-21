using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Inventario.Migrations
{
    /// <inheritdoc />
    public partial class Add_Column_Inventario_Descricao_Classificacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pro_Classificacao",
                schema: "Inventario",
                table: "Produto",
                type: "integer",
                maxLength: 1,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Pro_Descricao",
                schema: "Inventario",
                table: "Produto",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pro_Classificacao",
                schema: "Inventario",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Pro_Descricao",
                schema: "Inventario",
                table: "Produto");
        }
    }
}
