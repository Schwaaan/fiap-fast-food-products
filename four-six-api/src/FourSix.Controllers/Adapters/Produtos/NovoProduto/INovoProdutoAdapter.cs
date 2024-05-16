namespace FourSix.Controllers.Adapters.Produtos.NovoProduto
{
    public interface INovoProdutoAdapter
    {
        Task<NovoProdutoResponse> Inserir(NovoProdutoRequest produto);
    }
}
