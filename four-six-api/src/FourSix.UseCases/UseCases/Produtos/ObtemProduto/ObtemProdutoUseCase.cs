using FourSix.Domain.Entities.ProdutoAggregate;
using FourSix.UseCases.Interfaces;

namespace FourSix.UseCases.UseCases.Produtos.ObtemProduto
{
    public class ObtemProdutoUseCase : IObtemProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ObtemProdutoUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Task<Produto> Execute(Guid id) => ObterProduto(id);

        private async Task<Produto> ObterProduto(Guid id)
        {
            var produto = _produtoRepository.Obter(id);

            if (produto == null)
            {
                throw new Exception("Produto não encontrado");
            }

            return produto;
        }
    }
}