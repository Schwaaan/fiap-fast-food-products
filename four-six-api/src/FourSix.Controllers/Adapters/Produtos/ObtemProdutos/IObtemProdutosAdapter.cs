namespace FourSix.Controllers.Adapters.Produtos.ObtemProdutos
{
    public interface IObtemProdutosAdapter
    {
        Task<ObtemProdutosResponse> Listar();
    }
}
