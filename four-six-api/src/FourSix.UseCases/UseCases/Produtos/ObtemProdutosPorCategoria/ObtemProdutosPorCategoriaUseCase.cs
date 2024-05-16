using FourSix.Domain.Entities.ProdutoAggregate;
using FourSix.UseCases.Interfaces;

namespace FourSix.UseCases.UseCases.Produtos.ObtemProdutoPorCategoria
{
    public class ObtemProdutosPorCategoriaUseCase : IObtemProdutosPorCategoriaUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ObtemProdutosPorCategoriaUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Task<ICollection<Produto>> Execute(EnumCategoriaProduto categoria) => ObterProdutoPorCategoria(categoria);

        private async Task<ICollection<Produto>> ObterProdutoPorCategoria(EnumCategoriaProduto categoria)
        {
            var produtos = _produtoRepository
                  .Listar(x => x.Categoria == categoria
                  && x.Ativo).ToList();

            return produtos;
        }
    }
}