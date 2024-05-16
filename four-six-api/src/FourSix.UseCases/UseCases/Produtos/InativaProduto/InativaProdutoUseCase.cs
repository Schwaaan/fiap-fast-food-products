using FourSix.Domain.Entities.ProdutoAggregate;
using FourSix.UseCases.Interfaces;

namespace FourSix.UseCases.UseCases.Produtos.InativaProduto
{
    public class InativaProdutoUseCase : IInativaProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InativaProdutoUseCase(
            IProdutoRepository produtoRepository,
            IUnitOfWork unitOfWork)
        {
            _produtoRepository = produtoRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Produto> Execute(Guid produtoId) => ExcluirProduto(produtoId);

        private async Task<Produto> ExcluirProduto(Guid produtoId)
        {
            var produto = _produtoRepository
                .Obter(produtoId);

            if (produto == null)
            {
                throw new Exception("Produto não encontrado");
            }

            produto.InativarProduto();

            await _produtoRepository
                 .Alterar(produto)
                 .ConfigureAwait(false);

            await _unitOfWork
                .Save()
                .ConfigureAwait(false);

            produto = _produtoRepository.Listar(q => q.Id == produtoId).FirstOrDefault();

            return produto;
        }
    }
}
