using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.UseCases.UseCases.Produtos.ObtemProduto
{
    public interface IObtemProdutoUseCase
    {
        Task<Produto> Execute(Guid id);
    }
}
