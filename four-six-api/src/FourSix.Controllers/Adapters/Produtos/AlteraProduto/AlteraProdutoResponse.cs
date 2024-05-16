using FourSix.Controllers.ViewModels;

namespace FourSix.Controllers.Adapters.Produtos.AlteraProduto
{
    public class AlteraProdutoResponse
    {
        public AlteraProdutoResponse(ProdutoModel produtoModel) => this.Produto = produtoModel;
        public ProdutoModel Produto { get; }
    }
}
