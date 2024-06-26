﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Produto.Migrations
{
    /// <inheritdoc />
    public partial class CreateTable_Categoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Cat_CategoriaId",
                schema: "Inventario",
                table: "Produto",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Categoria",
                schema: "Inventario",
                columns: table => new
                {
                    Cat_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Cat_Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Cat_Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Categoria_Pro_Id",
                schema: "Inventario",
                table: "Produto");

            migrationBuilder.DropTable(
                name: "Categoria",
                schema: "Inventario");

            migrationBuilder.DropColumn(
                name: "Cat_CategoriaId",
                schema: "Inventario",
                table: "Produto");
        }
    }
}
