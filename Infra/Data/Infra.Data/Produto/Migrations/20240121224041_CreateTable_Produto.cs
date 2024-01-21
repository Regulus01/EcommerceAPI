using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Produto.Migrations
{
    /// <inheritdoc />
    public partial class CreateTable_Produto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Inventario");

            migrationBuilder.CreateTable(
                name: "Produto",
                schema: "Inventario",
                columns: table => new
                {
                    Pro_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Pro_Nome = table.Column<string>(type: "text", nullable: false),
                    Pro_Preco = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Pro_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto",
                schema: "Inventario");
        }
    }
}
