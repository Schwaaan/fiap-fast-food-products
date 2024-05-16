using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Test.Produtos
{
    public class UnitTest
    {
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
    }
}
