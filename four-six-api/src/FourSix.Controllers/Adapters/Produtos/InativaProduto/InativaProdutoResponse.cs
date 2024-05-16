using FourSix.Controllers.ViewModels;

namespace FourSix.Controllers.Adapters.Produtos.InativaProduto
{
    public class InativaProdutoResponse
    {
        public InativaProdutoResponse(ProdutoModel produtoModel) => this.Produto = produtoModel;
        public ProdutoModel Produto { get; }
    }
}
