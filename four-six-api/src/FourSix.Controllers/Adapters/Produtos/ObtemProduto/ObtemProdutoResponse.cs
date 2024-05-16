using FourSix.Controllers.ViewModels;

namespace FourSix.Controllers.Adapters.Produtos.ObtemProduto
{
    public class ObtemProdutoResponse
    {
        public ObtemProdutoResponse(ProdutoModel produtoModel) => this.Produto = produtoModel;
        public ProdutoModel Produto { get; }
    }
}
