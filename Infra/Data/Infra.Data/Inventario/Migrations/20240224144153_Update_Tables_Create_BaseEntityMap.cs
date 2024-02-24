using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Inventario.Migrations
{
    /// <inheritdoc />
    public partial class Update_Tables_Create_BaseEntityMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CriadoEm",
                schema: "Inventario",
                table: "Produto",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: DateTimeOffset.UtcNow);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModificadoEm",
                schema: "Inventario",
                table: "Produto",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: DateTimeOffset.UtcNow);

            migrationBuilder.AddColumn<int>(
                name: "Visualizacoes",
                schema: "Inventario",
                table: "Produto",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CriadoEm",
                schema: "Inventario",
                table: "Categoria",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: DateTimeOffset.UtcNow);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModificadoEm",
                schema: "Inventario",
                table: "Categoria",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: DateTimeOffset.UtcNow);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CriadoEm",
                schema: "Inventario",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "ModificadoEm",
                schema: "Inventario",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Visualizacoes",
                schema: "Inventario",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "CriadoEm",
                schema: "Inventario",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "ModificadoEm",
                schema: "Inventario",
                table: "Categoria");
        }
    }
}
