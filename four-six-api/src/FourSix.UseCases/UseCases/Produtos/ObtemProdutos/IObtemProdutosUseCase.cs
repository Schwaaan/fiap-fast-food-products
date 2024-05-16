using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.UseCases.UseCases.Produtos.ObtemProdutos
{
    public interface IObtemProdutosUseCase
    {
        Task<ICollection<Produto>> Execute();
    }
}
