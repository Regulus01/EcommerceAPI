using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Inventario.Migrations
{
    /// <inheritdoc />
    public partial class Rename_Column_id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pro_Id",
                schema: "Inventario",
                table: "Produto",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Cat_Id",
                schema: "Inventario",
                table: "Categoria",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Inventario",
                table: "Produto",
                newName: "Pro_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Inventario",
                table: "Categoria",
                newName: "Cat_Id");
        }
    }
}
