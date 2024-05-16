namespace FourSix.Controllers.Adapters.Produtos.ObtemProduto
{
    public interface IObtemProdutoAdapter
    {
        Task<ObtemProdutoResponse> Obter(Guid id);
    }
}
