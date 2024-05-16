using FourSix.Controllers.Gateways.Repositories;
using FourSix.Domain.Entities.ProdutoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Moq;

namespace FourSix.Test.Produtos
{
    public class RepositoryUnitTest
    {
        Mock<DbContext> dbContextMock;
        Mock<DbSet<Produto>> dbSetMock;

        public RepositoryUnitTest()
        {
            dbContextMock = new();
            dbSetMock = new();
        }

        [Fact]
        public void Obter_resultado_ok()
        {
            // Arrange
            var repository = new ProdutoRepository(dbContextMock.Object);
            var id = Guid.NewGuid();
            var produto = MontarClasseProduto();
            dbSetMock.Setup(m => m.Find(id)).Returns(produto);
            dbContextMock.Setup(m => m.Set<Produto>()).Returns(dbSetMock.Object);

            // Act
            var resultado = repository.Obter(id);

            // Assert
            Assert.Equal(produto, resultado);
        }

        [Fact]
        public async Task Incluir_produto_ok()
        {
            // Arrange
            var repository = new ProdutoRepository(dbContextMock.Object);
            var produto = MontarClasseProduto();
            dbContextMock.Setup(m => m.Set<Produto>()).Returns(dbSetMock.Object);

            // Act
            await repository.Incluir(produto);

            // Assert
            dbSetMock.Verify(m => m.AddAsync(It.IsAny<Produto>(), CancellationToken.None), Times.Once);
        }

        //[Fact]
        //public async Task Excluir_Sets_Entity_State_Deleted()
        //{
        //    // Arrange
        //    var setId = Guid.NewGuid();
        //    var produto = MontarClasseProduto();
        //    dbSetMock.Setup(m => m.FindAsync(setId)).ReturnsAsync(produto);
        //    dbContextMock.Setup(m => m.Set<Produto>()).Returns(dbSetMock.Object);
        //    dbContextMock.Setup(m => m.Entry(produto).State).Returns(EntityState.Deleted);

        //    var iStateManager = new Mock<IStateManager>();
        //    var model = new Mock<Model>();

        //    var entityEntryMock = new Mock<EntityEntry<Produto>>();

        //    //var productEntityEntry = new Mock<EntityEntry<Produto>>();
        //    //productEntityEntry.SetupGet(m => m.Entity).Returns(produto);

        //    //(        new InternalShadowEntityEntry(iStateManager.Object, new EntityType("Produto", model.Object, true, ConfigurationSource.Convention)));




        //    var repository = new ProdutoRepository(dbContextMock.Object);

        //    // Act
        //    await repository.Excluir(setId);

        //    // Assert
        //    //dbContextMock.Verify(m => m.Entry(produto).State, Times.Once);
        //    entityEntryMock.VerifySet(m => m.State = EntityState.Deleted, Times.Once);
        //}

        //[Fact]
        //public void Listar_Returns_All_Products_When_No_Predicate_Provided()
        //{
        //    // Arrange
        //    var repository = new ProdutoRepository(dbContextMock.Object);
        //    var produto1 = MontarClasseProduto();
        //    var produto2 = MontarClasseProduto();
        //    List<Produto> produtos = new List<Produto> { produto1, produto2 };
        //    //dbSetMock.Setup(m => m).Returns(produtos.AsQueryable());
        //    dbContextMock.Setup(m => m.Set<Produto>()).Returns(dbSetMock.Object);

        //    // Act
        //    var resultado = repository.Listar(null);

        //    // Assert
        //    Assert.Equal(produtos, resultado);
        //}

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
