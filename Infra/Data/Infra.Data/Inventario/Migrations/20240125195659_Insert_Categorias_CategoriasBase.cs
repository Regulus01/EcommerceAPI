using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Inventario.Migrations
{
    /// <inheritdoc />
    public partial class Insert_Categorias_CategoriasBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Inventario",
                table: "Categoria",
                columns: new [] { "Cat_Id", "Cat_Nome" },
                values: new object[,]
                {
                    { "59a0494d-2a2c-4f5a-8b9c-3afb418ed90e", "Eletrônicos" },
                    { "289327f3-033b-40d6-9e8e-995024b1b7f7", "Vestuário e Moda" },
                    { "c6c1cbb9-1281-4928-af6f-c0ddd0d353fb", "Alimentos e Bebidas" },
                    { "1f1c46e1-1f43-4904-89a6-27fb905545fd", "Móveis e Decoração" },
                    { "cae8e52e-2e8c-432f-abe1-5ed89198e3f6", "Cuidados Pessoais e Beleza" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Inventario",
                table: "Categoria",
                keyColumn: "Cat_Id",
                keyValues: new [] {
                    "59a0494d-2a2c-4f5a-8b9c-3afb418ed90e",
                    "289327f3-033b-40d6-9e8e-995024b1b7f7",
                    "c6c1cbb9-1281-4928-af6f-c0ddd0d353fb",
                    "1f1c46e1-1f43-4904-89a6-27fb905545fd",
                    "cae8e52e-2e8c-432f-abe1-5ed89198e3f6"});
        }
    }
}
