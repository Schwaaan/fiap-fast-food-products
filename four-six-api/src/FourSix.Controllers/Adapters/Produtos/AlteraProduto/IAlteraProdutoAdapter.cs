namespace FourSix.Controllers.Adapters.Produtos.AlteraProduto
{
    public interface IAlteraProdutoAdapter
    {
        Task<AlteraProdutoResponse> Alterar(Guid id, AlteraProdutoRequest produto);
    }
}
