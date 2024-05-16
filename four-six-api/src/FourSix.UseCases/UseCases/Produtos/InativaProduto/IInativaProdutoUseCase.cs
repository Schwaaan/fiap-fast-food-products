using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.UseCases.UseCases.Produtos.InativaProduto
{
    public interface IInativaProdutoUseCase
    {
        /// <summary>
        /// Executa o Caso de Uso
        /// </summary>
        Task<Produto> Execute(Guid produtoId);
    }
}
