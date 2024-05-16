using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.UseCases.UseCases.Produtos.AlteraProduto
{
    public interface IAlteraProdutoUseCase
    {
        /// <summary>
        /// Executa o Caso de Uso
        /// </summary>
        Task<Produto> Execute(Guid produtoId, string nome, string descricao, EnumCategoriaProduto categoria, decimal preco);
    }
}
