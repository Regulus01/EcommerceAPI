﻿// <auto-generated />
using System;
using Infra.Data.Arquivos.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infra.Data.Arquivos.Migrations
{
    [DbContext(typeof(GerenciadorDeArquivosContext))]
    [Migration("20240128182728_CreateTable_GerenciadorDeArquivos")]
    partial class CreateTable_GerenciadorDeArquivos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Arquivos.Entities.GerenciadorDeArquivos", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Ger_Id");

                    b.Property<string>("Caminho")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Ger_Caminho");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Ger_ContentType");

                    b.Property<string>("Entidade")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Ger_Entidade");

                    b.Property<Guid>("EntidadeId")
                        .HasColumnType("uuid")
                        .HasColumnName("Ger_EntidadeId");

                    b.Property<int>("Ordem")
                        .HasColumnType("integer")
                        .HasColumnName("Ger_Ordem");

                    b.HasKey("Id");

                    b.ToTable("GerenciadorDeArquivos", "Arquivos");
                });
#pragma warning restore 612, 618
        }
    }
}
