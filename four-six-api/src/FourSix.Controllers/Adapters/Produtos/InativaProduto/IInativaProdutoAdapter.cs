namespace FourSix.Controllers.Adapters.Produtos.InativaProduto
{
    public interface IInativaProdutoAdapter
    {
        Task<InativaProdutoResponse> Inativar(Guid id);
    }
}
