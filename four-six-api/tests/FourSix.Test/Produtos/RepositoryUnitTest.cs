using FourSix.Controllers.Gateways.Configurations;
using FourSix.Controllers.Gateways.DataAccess;
using FourSix.Controllers.Gateways.Repositories;
using FourSix.Controllers.Gateways.Repositories.Cache;
using FourSix.Domain.Entities.ProdutoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

        #region [ Produto ]

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
            var produtos = new List<Produto> { MontarClasseProduto() };
            var produtoIncluir = produtos.FirstOrDefault();
            var repository = new ProdutoRepository(dbContextMock.Object);

            var mockSet = new Mock<DbSet<Produto>>();

            dbContextMock.Setup(c => c.Set<Produto>()).Returns(mockSet.Object);


            // Act
            await repository.Incluir(produtoIncluir);
            var _unitOfWork = new UnitOfWork(dbContextMock.Object);
            await _unitOfWork.Save();

            // Assert
            mockSet.Verify(m => m.AddAsync(It.IsAny<Produto>(), CancellationToken.None), Times.Once);
        }

        #endregion

        #region [ Configuration ]

        [Fact]
        public void Produto_configuration_erro()
        {
            // Arrange
            var produtoConfiguration = new ProdutoConfiguration();

            // Act
            Action act = () => produtoConfiguration.Configure(null);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void Produto_configuration_ok()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ProdutoDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new ProdutoDbContext(options);
            var modelBuilder = new ModelBuilder();
            var produtoConfiguration = new ProdutoConfiguration();

            // Act
            produtoConfiguration.Configure(modelBuilder.Entity<Produto>());

            // Assert
            var entityType = modelBuilder.Model.FindEntityType(typeof(Produto));
            Assert.NotNull(entityType);

            Assert.Equal("Produto", entityType.GetTableName());
            Assert.Equal(nameof(Produto.Id), entityType.FindPrimaryKey().Properties.First().Name);

            Assert.Equal(50, entityType.FindProperty(nameof(Produto.Nome)).GetMaxLength());
            Assert.Equal(200, entityType.FindProperty(nameof(Produto.Descricao)).GetMaxLength());
            Assert.Equal(6, entityType.FindProperty(nameof(Produto.Preco)).GetPrecision());
            Assert.Equal(2, entityType.FindProperty(nameof(Produto.Preco)).GetScale());
        }

        [Fact]
        public void Seed_erro()
        {
            // Arrange


            // Act
            Action act = () => SeedData.Seed(null);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
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

    public class ProdutoDbContext : DbContext
    {
        public ProdutoDbContext(DbContextOptions<ProdutoDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new ProdutoConfiguration().Configure(modelBuilder.Entity<Produto>());
        }
    }
}
