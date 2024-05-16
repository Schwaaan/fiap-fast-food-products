using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Test.Produtos
{
    public class DomainUnitTest
    {
        #region [ Classe Produto ]

        [Fact]
        public void Cria_classe_produto_ok()
        {
            Guid id = Guid.NewGuid();
            string nome = "Teste de produto";
            string descricao = "Produto de teste sendo testado com descricao";
            EnumCategoriaProduto categoria = EnumCategoriaProduto.Lanche;
            decimal preco = 10.90M;
            bool ativo = true;

            Produto produto = new(id,
                nome,
                descricao,
                categoria,
                preco,
                ativo);

            Assert.Equal(id, produto.Id);
            Assert.Equal(nome, produto.Nome);
            Assert.Equal(descricao, produto.Descricao);
            Assert.Equal(categoria, produto.Categoria);
            Assert.Equal(preco, produto.Preco);
            Assert.Equal(ativo, produto.Ativo);
        }

        [Fact]
        public void Inativar_produto_ok()
        {
            Guid id = Guid.NewGuid();
            string nome = "Teste de produto";
            string descricao = "Produto de teste sendo testado com descricao";
            EnumCategoriaProduto categoria = EnumCategoriaProduto.Lanche;
            decimal preco = 10.90M;
            bool ativo = true;

            Produto produto = new(id,
                nome,
                descricao,
                categoria,
                preco,
                ativo);

            produto.InativarProduto();

            Assert.False(produto.Ativo);
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
