using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Inventario.Migrations
{
    /// <inheritdoc />
    public partial class Update_Produtos_CorrecaoNoRelacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Categoria_Pro_Id",
                schema: "Inventario",
                table: "Produto");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_Cat_CategoriaId",
                schema: "Inventario",
                table: "Produto",
                column: "Cat_CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Categoria_Cat_CategoriaId",
                schema: "Inventario",
                table: "Produto",
                column: "Cat_CategoriaId",
                principalSchema: "Inventario",
                principalTable: "Categoria",
                principalColumn: "Cat_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Categoria_Cat_CategoriaId",
                schema: "Inventario",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_Cat_CategoriaId",
                schema: "Inventario",
                table: "Produto");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Categoria_Pro_Id",
                schema: "Inventario",
                table: "Produto",
                column: "Pro_Id",
                principalSchema: "Inventario",
                principalTable: "Categoria",
                principalColumn: "Cat_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
