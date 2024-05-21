using Azure.Core;
using FourSix.Controllers.Adapters.Produtos.AlteraProduto;
using FourSix.Controllers.Adapters.Produtos.InativaProduto;
using FourSix.Controllers.Adapters.Produtos.NovoProduto;
using FourSix.Controllers.Adapters.Produtos.ObtemProduto;
using FourSix.Controllers.Adapters.Produtos.ObtemProdutos;
using FourSix.Controllers.Adapters.Produtos.ObtemProdutosPorCategoria;
using FourSix.Controllers.ViewModels;
using FourSix.Domain.Entities.ProdutoAggregate;
using FourSix.UseCases.UseCases.Produtos.AlteraProduto;
using FourSix.UseCases.UseCases.Produtos.InativaProduto;
using FourSix.UseCases.UseCases.Produtos.NovoProduto;
using FourSix.UseCases.UseCases.Produtos.ObtemProduto;
using FourSix.UseCases.UseCases.Produtos.ObtemProdutoPorCategoria;
using FourSix.UseCases.UseCases.Produtos.ObtemProdutos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSix.Test.Produtos
{
    public class AdapterUnitTest
    {
        #region [ AlteraProdutoAdapter ]

        [Fact]
        public async Task Alterar_produto_ok()
        {
            // Arrange
            var mockUseCase = new Mock<IAlteraProdutoUseCase>();
            var produto = MontarClasseProduto();
            mockUseCase.Setup(x => x.Execute(produto.Id, produto.Nome, produto.Descricao, produto.Categoria, produto.Preco)).ReturnsAsync(produto);
            var adapter = new AlteraProdutoAdapter(mockUseCase.Object);
            var request = new AlteraProdutoRequest
            {
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Categoria = produto.Categoria,
                Preco = produto.Preco
            };

            // Act
            var response = await adapter.Alterar(produto.Id, request);

            // Assert
            Assert.NotNull(response);
            Assert.IsType<AlteraProdutoResponse>(response);
            Assert.Equal(produto.Id, response.Produto.Id);
            Assert.Equal(request.Nome, response.Produto.Nome);
            Assert.Equal(request.Descricao, response.Produto.Descricao);
            Assert.Equal(request.Categoria, response.Produto.Categoria);

            mockUseCase.Verify(x => x.Execute(produto.Id, produto.Nome, produto.Descricao, produto.Categoria, produto.Preco), Times.Once);
        }

        #endregion

        #region [ InativaProdutoAdapter ]

        [Fact]
        public async Task Inativa_produto_ok()
        {
            // Arrange
            var mockUseCase = new Mock<IInativaProdutoUseCase>();
            var produto = MontarClasseProduto();
            mockUseCase.Setup(x => x.Execute(produto.Id)).ReturnsAsync(produto);
            var adapter = new InativaProdutoAdapter(mockUseCase.Object);

            // Act
            var response = await adapter.Inativar(produto.Id);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(produto.Id, response.Produto.Id);
            mockUseCase.Verify(x => x.Execute(produto.Id), Times.Once);
        }

        #endregion

        #region [ NovoProdutoAdapter ]

        [Fact]
        public async Task Novo_produto_ok()
        {
            // Arrange
            var mockUseCase = new Mock<INovoProdutoUseCase>();
            var produto = MontarClasseProduto();
            mockUseCase.Setup(x => x.Execute(produto.Nome, produto.Descricao, produto.Categoria, produto.Preco)).ReturnsAsync(produto);
            var adapter = new NovoProdutoAdapter(mockUseCase.Object);
            var request = new NovoProdutoRequest
            {
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Categoria = produto.Categoria,
                Preco = produto.Preco
            };

            // Act
            var response = await adapter.Inserir(request);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(request.Nome, response.Produto.Nome);
            Assert.Equal(request.Descricao, response.Produto.Descricao);
            Assert.Equal(request.Categoria, response.Produto.Categoria);

            mockUseCase.Verify(x => x.Execute(produto.Nome, produto.Descricao, produto.Categoria, produto.Preco), Times.Once);
        }

        #endregion

        #region [ ObtemProdutoAdapter ]

        [Fact]
        public async Task Obtem_produto_ok()
        {
            // Arrange
            var mockUseCase = new Mock<IObtemProdutoUseCase>();
            var produto = MontarClasseProduto();
            mockUseCase.Setup(x => x.Execute(produto.Id)).ReturnsAsync(produto);
            var adapter = new ObtemProdutoAdapter(mockUseCase.Object);

            // Act
            var response = await adapter.Obter(produto.Id);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(produto.Id, response.Produto.Id);
            Assert.Equal(produto.Nome, response.Produto.Nome);
            mockUseCase.Verify(x => x.Execute(produto.Id), Times.Once);
        }

        #endregion

        #region [ ObtemProdutosAdapter ]

        [Fact]
        public async Task Obtem_produtos_ok()
        {
            // Arrange
            var mockUseCase = new Mock<IObtemProdutosUseCase>();
            var produto = MontarClasseProduto();
            mockUseCase.Setup(x => x.Execute()).ReturnsAsync(new List<Produto> { produto });
            var adapter = new ObtemProdutosAdapter(mockUseCase.Object);
            // Act
            var response = await adapter.Listar();

            // Assert
            Assert.NotNull(response);
            Assert.True(response.Produtos.Any());
            mockUseCase.Verify(x => x.Execute(), Times.Once);
        }

        #endregion

        #region [ ObtemProdutosPorCategoriaAdapter ]

        [Fact]
        public async Task Obtem_produtos_por_categoria_ok()
        {
            // Arrange
            var mockUseCase = new Mock<IObtemProdutosPorCategoriaUseCase>();
            var produto = MontarClasseProduto();
            mockUseCase.Setup(x => x.Execute(produto.Categoria)).ReturnsAsync(new List<Produto> { produto });
            var adapter = new ObtemProdutosPorCategoriaAdapter(mockUseCase.Object);

            // Act
            var response = await adapter.Obter(produto.Categoria);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.Produtos.Where(a => a.Categoria == produto.Categoria).Any());
            mockUseCase.Verify(x => x.Execute(produto.Categoria), Times.Once);
        }

        #endregion

        #region [ Métodos privados ]

        private Produto MontarClasseProduto(Guid? id = null, string? nome = null, string? descricao = null, EnumCategoriaProduto? categoria = null, decimal? preco = null, bool? ativo = null)
        {
            id ??= Guid.NewGuid();

            return new(id.Value,
                nome ?? "Teste de produto",
                descricao ?? "Produto de teste sendo testado com descricao",
                categoria != null ? categoria.Value : EnumCategoriaProduto.Lanche,
                preco ?? 10.90M,
                ativo ?? true);
        }

        #endregion
    }
}
