using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.UseCases.Interfaces
{
    public interface IProdutoRepository : IGetRepository<Produto>, ISetRepository<Produto>
    {
    }
}
