﻿// <auto-generated />
using System;
using Infra.Data.Inventario.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infra.Data.Inventario.Migrations
{
    [DbContext(typeof(InventarioContext))]
    [Migration("20240125195659_Insert_Categorias_CategoriasBase")]
    partial class Insert_Categorias_CategoriasBase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Authentication.Produto.Entities.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Cat_Id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Cat_Nome");

                    b.HasKey("Id");

                    b.ToTable("Categoria", "Inventario");
                });

            modelBuilder.Entity("Domain.Authentication.Produto.Entities.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Pro_Id");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uuid")
                        .HasColumnName("Cat_CategoriaId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Pro_Nome");

                    b.Property<decimal>("Preco")
                        .HasColumnType("numeric")
                        .HasColumnName("Pro_Preco");

                    b.HasKey("Id");

                    b.ToTable("Produto", "Inventario");
                });

            modelBuilder.Entity("Domain.Authentication.Produto.Entities.Produto", b =>
                {
                    b.HasOne("Domain.Authentication.Produto.Entities.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Domain.Authentication.Produto.Entities.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
