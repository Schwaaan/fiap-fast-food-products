using FourSix.Domain.Entities.ProdutoAggregate;
using FourSix.UseCases.Interfaces;

namespace FourSix.UseCases.UseCases.Produtos.ObtemProdutos
{
    public class ObtemProdutosUseCase : IObtemProdutosUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ObtemProdutosUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Task<ICollection<Produto>> Execute() => ObtemProdutos();

        private async Task<ICollection<Produto>> ObtemProdutos()
        {
            var produtos = _produtoRepository
                .Listar()
                .Where(q => q.Ativo).ToList();

            return produtos;
        }
    }
}