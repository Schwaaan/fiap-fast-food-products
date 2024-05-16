using FourSix.Domain.Entities.ProdutoAggregate;
using FourSix.UseCases.Interfaces;
using FourSix.UseCases.UseCases.Produtos.AlteraProduto;
using FourSix.UseCases.UseCases.Produtos.InativaProduto;
using FourSix.UseCases.UseCases.Produtos.NovoProduto;
using FourSix.UseCases.UseCases.Produtos.ObtemProduto;
using FourSix.UseCases.UseCases.Produtos.ObtemProdutoPorCategoria;
using FourSix.UseCases.UseCases.Produtos.ObtemProdutos;
using Moq;
using NuGet.Frameworks;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace FourSix.Test.Produtos
{
    public class UseCasesTest
    {
        private Mock<IProdutoRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;

        public UseCasesTest()
        {
            _mockRepository = new();
            _mockUnitOfWork = new();
        }

        #region [Private methods]

        private Produto GerarProduto(Guid? id = null, string? nome = null, string? descricao = null, EnumCategoriaProduto? categoria = null, decimal? preco = null, bool? ativo = null)
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

        #region [AlteraProdutoUseCase]

        [Fact]
        public async void Altera_produto_ok()
        {
            //Arrange
            AlteraProdutoUseCase useCase = new(_mockRepository.Object, _mockUnitOfWork.Object);
            Produto produto = GerarProduto(categoria: EnumCategoriaProduto.Lanche, ativo: true);
            _mockRepository.Setup(repo => repo.Obter(produto.Id)).Returns(produto);
            _mockRepository.Setup(repo => repo.Alterar(produto)).Returns(Task.CompletedTask);
            _mockRepository.Setup(repo => repo.Listar(It.IsAny<Expression<Func<Produto, bool>>>())).Returns((Expression<Func<Produto, bool>> predicate) => new List<Produto> { produto }.AsQueryable().Where(predicate).ToList());

            string nome = "Novo nome";
            string descricao = "Nova descrição";
            EnumCategoriaProduto enumCategoria = EnumCategoriaProduto.Sobremesa;
            decimal preco = 34.21M;

            //Act
            Produto resultado = await useCase.Execute(produto.Id, nome, descricao, enumCategoria, preco);

            //Assert
            Assert.IsType<Produto>(resultado);
            Assert.Equal(nome, resultado.Nome);
            Assert.Equal(descricao, resultado.Descricao);
            Assert.Equal(enumCategoria, resultado.Categoria);
            Assert.Equal(preco, resultado.Preco);
            _mockRepository.Verify(repo => repo.Alterar(It.IsAny<Produto>()), Times.Once);
            _mockUnitOfWork.Verify(unit => unit.Save(), Times.Once);
        }

        [Fact]
        public void Altera_produto_erro()
        {
            Assert.Throws<Exception>(() =>
            {
                return new NotImplementedException();
            });
        }

        #endregion

        #region [InativaProdutoUseCase]

        [Fact]
        public async void Inativa_produto_ok()
        {
            //Arrange
            InativaProdutoUseCase useCase = new(_mockRepository.Object, _mockUnitOfWork.Object);
            Produto produto = GerarProduto(ativo: true);
            _mockRepository.Setup(repo => repo.Obter(produto.Id)).Returns(produto);
            _mockRepository.Setup(repo => repo.Alterar(produto)).Returns(Task.CompletedTask);
            _mockRepository.Setup(repo => repo.Listar(It.IsAny<Expression<Func<Produto, bool>>>())).Returns((Expression<Func<Produto, bool>> predicate) => new List<Produto> { produto }.AsQueryable().Where(predicate).ToList());

            //Act
            Produto resultado = await useCase.Execute(produto.Id);

            //Assert
            Assert.IsType<Produto>(resultado);
            Assert.False(resultado.Ativo);
            _mockRepository.Verify(repo => repo.Alterar(It.IsAny<Produto>()), Times.Once);
            _mockUnitOfWork.Verify(unit => unit.Save(), Times.Once);
        }

        [Fact]
        public async void Inativa_produto_inexistente()
        {
            //Arrange
            InativaProdutoUseCase useCase = new(_mockRepository.Object, _mockUnitOfWork.Object);
            Produto produto = GerarProduto();
            _mockRepository.Setup(repo => repo.Obter(It.IsAny<Guid>())).Returns(() => null);

            //Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(() => useCase.Execute(produto.Id)).Result;
            Assert.Equal("Produto não encontrado", ex.Message);
            _mockRepository.Verify(repo => repo.Alterar(It.IsAny<Produto>()), Times.Never);
            _mockUnitOfWork.Verify(unit => unit.Save(), Times.Never);
        }

        #endregion

        #region [NovoProdutoUseCase]

        [Fact]
        public async void Inclui_novo_produto_ok()
        {
            //Arrange
            NovoProdutoUseCase useCase = new(_mockRepository.Object, _mockUnitOfWork.Object);
            Produto produto = GerarProduto();
            _mockRepository.Setup(repo => repo.Incluir(It.IsAny<Produto>())).Returns(Task.CompletedTask);

            //Act
            var prod = await useCase.Execute(produto.Nome, produto.Descricao, produto.Categoria, produto.Preco);

            //Assert
            Assert.IsType<Produto>(prod);
            _mockRepository.Verify(repo => repo.Incluir(It.IsAny<Produto>()), Times.Once);
            _mockUnitOfWork.Verify(unit => unit.Save(), Times.Once);
        }

        [Fact]
        public async void Inclui_novo_produto_duplicado()
        {
            //Arrange
            NovoProdutoUseCase useCase = new(_mockRepository.Object, _mockUnitOfWork.Object);
            Produto produto = GerarProduto();
            _mockRepository.Setup(repo => repo.Incluir(It.IsAny<Produto>())).Returns(Task.CompletedTask);
            _mockRepository.Setup(repo => repo.Listar(It.IsAny<Expression<Func<Produto, bool>>>())).Returns((Expression<Func<Produto, bool>> predicate) => new List<Produto> { produto }.AsQueryable().Where(predicate).ToList());

            //Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await useCase.Execute(produto.Nome, produto.Descricao, produto.Categoria, produto.Preco));
            _mockRepository.Verify(repo => repo.Incluir(It.IsAny<Produto>()), Times.Never);
            _mockUnitOfWork.Verify(unit => unit.Save(), Times.Never);
        }

        #endregion

        #region [ObtemProdutoUseCase]

        [Fact]
        public void Obtem_produto_ok()
        {
            //Arrange
            ObtemProdutoUseCase obtemProdutoUseCase = new(_mockRepository.Object);
            Produto produto = GerarProduto();
            _mockRepository.Setup(s => s.Obter(produto.Id)).Returns(produto);

            //Act
            var esperado = obtemProdutoUseCase.Execute(produto.Id).Result;

            //Assert
            Assert.Equal(produto, esperado);
        }

        [Fact]
        public void Obtem_produto_inexistente()
        {
            //Arrange
            ObtemProdutoUseCase useCase = new(_mockRepository.Object);
            Produto produto = GerarProduto();
            _mockRepository.Setup(s => s.Obter(It.IsAny<Guid>())).Returns(() => null);

            //Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await useCase.Execute(Guid.NewGuid()));
        }

        #endregion

        #region [ObtemProdutosUseCase]

        [Fact]
        public void Obtem_lista_produtos_ok()
        {
            //Arrange
            ObtemProdutosUseCase useCase = new(_mockRepository.Object);
            Produto produto1 = GerarProduto();
            Produto produto2 = GerarProduto();
            var produtos = new List<Produto> { produto1, produto2 };
            _mockRepository.Setup(s => s.Listar(null)).Returns(produtos);

            //Act
            var resultado = useCase.Execute();

            //Assert
            Assert.Equal(produtos, resultado.Result);
        }

        #endregion

        #region [ObtemProdutosPorCategoriaUseCase]

        [Fact]
        public void Obtem_produtos_por_categoria_ok()
        {
            //Arrange
            ObtemProdutosPorCategoriaUseCase useCase = new(_mockRepository.Object);
            Produto produto1 = GerarProduto(categoria: EnumCategoriaProduto.Acompanhamento);
            Produto produto2 = GerarProduto(categoria: EnumCategoriaProduto.Acompanhamento);
            List<Produto> produtos = new List<Produto> { produto1, produto2 };
            _mockRepository.Setup(repo => repo.Listar(It.IsAny<Expression<Func<Produto, bool>>>())).Returns((Expression<Func<Produto, bool>> predicate) => produtos.AsQueryable().Where(predicate).ToList());

            //Act
            var resultado = useCase.Execute(categoria: EnumCategoriaProduto.Acompanhamento);

            //Assert
            Assert.Equal(produtos, resultado.Result);
        }

        [Fact]
        public void Obtem_produtos_por_categoria_erro()
        {
            //Arrange
            ObtemProdutosPorCategoriaUseCase useCase = new(_mockRepository.Object);
            Produto produto1 = GerarProduto(categoria: EnumCategoriaProduto.Acompanhamento);
            Produto produto2 = GerarProduto(categoria: EnumCategoriaProduto.Acompanhamento);
            Produto produto3 = GerarProduto(categoria: EnumCategoriaProduto.Lanche);
            List<Produto> produtos = new List<Produto> { produto1, produto2, produto3 };
            _mockRepository.Setup(repo => repo.Listar(It.IsAny<Expression<Func<Produto, bool>>>())).Returns((Expression<Func<Produto, bool>> predicate) => produtos.AsQueryable().Where(predicate).ToList());

            //Act
            var resultado = useCase.Execute(categoria: EnumCategoriaProduto.Acompanhamento);

            //Assert
            Assert.NotEqual(produtos, resultado.Result);
        }

        #endregion
    }
}
