using FourSix.Controllers.ViewModels;

namespace FourSix.Controllers.Adapters.Produtos.NovoProduto
{
    public class NovoProdutoResponse
    {
        public NovoProdutoResponse(ProdutoModel produtoModel) => this.Produto = produtoModel;
        public ProdutoModel Produto { get; }
    }
}
