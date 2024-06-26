﻿// <auto-generated />
using System;
using FourSix.Controllers.Gateways.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FourSix.Controllers.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240514010456_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FourSix.Domain.Entities.ProdutoAggregate.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("Categoria")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Preco")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("Id");

                    b.ToTable("Produto", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("63c776f5-4539-478e-a17a-54d3a1c2d3ee"),
                            Ativo = true,
                            Categoria = 1,
                            Descricao = "Pão, carne, alface, tomate e maionese ESPECIAL",
                            Nome = "Burger Four",
                            Preco = 5.5m
                        },
                        new
                        {
                            Id = new Guid("7686debb-92c2-4d89-a669-8988da8e8c72"),
                            Ativo = true,
                            Categoria = 1,
                            Descricao = "Pão, carne, queijo, alface, tomate e maionese ESPECIAL",
                            Nome = "Burguer Six",
                            Preco = 7.5m
                        },
                        new
                        {
                            Id = new Guid("947e3d62-26fa-4ba6-8395-39c259fc43ec"),
                            Ativo = true,
                            Categoria = 1,
                            Descricao = "Pão, carne, queijo, ovo, bacon, alface, tomate e maionese ESPECIAL",
                            Nome = "Burguer FourSix",
                            Preco = 10m
                        },
                        new
                        {
                            Id = new Guid("9482fcf0-e9e4-4bdc-869f-ad7d1d15016c"),
                            Ativo = true,
                            Categoria = 4,
                            Descricao = "Coca-cola 600ml",
                            Nome = "Coca-cola",
                            Preco = 8.25m
                        },
                        new
                        {
                            Id = new Guid("a0d0225e-0f3c-42ff-935d-beb44bb2cac4"),
                            Ativo = true,
                            Categoria = 4,
                            Descricao = "H2O 500ml",
                            Nome = "H2O",
                            Preco = 8.25m
                        },
                        new
                        {
                            Id = new Guid("a45a3af2-17db-459f-867a-b0c2e1261dc0"),
                            Ativo = true,
                            Categoria = 4,
                            Descricao = "Suco Natural de Laranja 500ml",
                            Nome = "Suco Natural de Laranja",
                            Preco = 10m
                        },
                        new
                        {
                            Id = new Guid("c2a49da0-6bc2-4cdc-be77-97d0284b8c92"),
                            Ativo = true,
                            Categoria = 2,
                            Descricao = "Batata Frita especial",
                            Nome = "Batata Frita",
                            Preco = 6.50m
                        },
                        new
                        {
                            Id = new Guid("c55a9ca7-411d-4245-8b91-1efbc30f7a9b"),
                            Ativo = true,
                            Categoria = 2,
                            Descricao = "Cebola empanada especial",
                            Nome = "Onion",
                            Preco = 8.25m
                        },
                        new
                        {
                            Id = new Guid("d23c72b6-0bbe-4e0d-a46e-b8d72da5e9ef"),
                            Ativo = true,
                            Categoria = 3,
                            Descricao = "Casquinha de sorvete de baunilha",
                            Nome = "Sorvete de Baunilha",
                            Preco = 1.25m
                        },
                        new
                        {
                            Id = new Guid("ea5df339-afd7-41b6-a4ab-44979c1d919d"),
                            Ativo = true,
                            Categoria = 3,
                            Descricao = "Bolo de chocolate com recheio de creme de morango",
                            Nome = "Bolo Sensação",
                            Preco = 3.25m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
