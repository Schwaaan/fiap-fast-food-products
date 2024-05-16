using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Controllers.Adapters.Produtos.ObtemProdutosPorCategoria
{
    public interface IObtemProdutosPorCategoriaAdapter
    {
        Task<ObtemProdutosPorCategoriaResponse> Obter(EnumCategoriaProduto categoria);
    }
}
