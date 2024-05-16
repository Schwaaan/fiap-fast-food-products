using FourSix.Controllers.ViewModels;

namespace FourSix.Controllers.Adapters.Produtos.ObtemProdutos
{
    public class ObtemProdutosResponse
    {
        public ObtemProdutosResponse(ICollection<ProdutoModel> produtosModel) => this.Produtos = produtosModel;
        public ICollection<ProdutoModel> Produtos { get; }
    }
}
