using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FourSix.Controllers.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Categoria = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Ativo", "Categoria", "Descricao", "Nome", "Preco" },
                values: new object[,]
                {
                    { new Guid("63c776f5-4539-478e-a17a-54d3a1c2d3ee"), true, 1, "Pão, carne, alface, tomate e maionese ESPECIAL", "Burger Four", 5.5m },
                    { new Guid("7686debb-92c2-4d89-a669-8988da8e8c72"), true, 1, "Pão, carne, queijo, alface, tomate e maionese ESPECIAL", "Burguer Six", 7.5m },
                    { new Guid("947e3d62-26fa-4ba6-8395-39c259fc43ec"), true, 1, "Pão, carne, queijo, ovo, bacon, alface, tomate e maionese ESPECIAL", "Burguer FourSix", 10m },
                    { new Guid("9482fcf0-e9e4-4bdc-869f-ad7d1d15016c"), true, 4, "Coca-cola 600ml", "Coca-cola", 8.25m },
                    { new Guid("a0d0225e-0f3c-42ff-935d-beb44bb2cac4"), true, 4, "H2O 500ml", "H2O", 8.25m },
                    { new Guid("a45a3af2-17db-459f-867a-b0c2e1261dc0"), true, 4, "Suco Natural de Laranja 500ml", "Suco Natural de Laranja", 10m },
                    { new Guid("c2a49da0-6bc2-4cdc-be77-97d0284b8c92"), true, 2, "Batata Frita especial", "Batata Frita", 6.50m },
                    { new Guid("c55a9ca7-411d-4245-8b91-1efbc30f7a9b"), true, 2, "Cebola empanada especial", "Onion", 8.25m },
                    { new Guid("d23c72b6-0bbe-4e0d-a46e-b8d72da5e9ef"), true, 3, "Casquinha de sorvete de baunilha", "Sorvete de Baunilha", 1.25m },
                    { new Guid("ea5df339-afd7-41b6-a4ab-44979c1d919d"), true, 3, "Bolo de chocolate com recheio de creme de morango", "Bolo Sensação", 3.25m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
