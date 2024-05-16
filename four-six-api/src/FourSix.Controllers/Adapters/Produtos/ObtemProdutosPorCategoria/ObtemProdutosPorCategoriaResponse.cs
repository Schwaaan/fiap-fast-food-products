using FourSix.Controllers.ViewModels;

namespace FourSix.Controllers.Adapters.Produtos.ObtemProdutosPorCategoria
{
    public class ObtemProdutosPorCategoriaResponse
    {
        public ObtemProdutosPorCategoriaResponse(ICollection<ProdutoModel> produtosModel) => this.Produtos = produtosModel;
        public ICollection<ProdutoModel> Produtos { get; }
    }
}
