using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.UseCases.UseCases.Produtos.NovoProduto
{
    public interface INovoProdutoUseCase
    {
        Task<Produto> Execute(string nome, string descricao, EnumCategoriaProduto categoria, decimal preco);
    }
}
