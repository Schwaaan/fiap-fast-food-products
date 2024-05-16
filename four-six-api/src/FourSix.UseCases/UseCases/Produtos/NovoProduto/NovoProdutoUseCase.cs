using FourSix.Domain.Entities.ProdutoAggregate;
using FourSix.UseCases.Interfaces;

namespace FourSix.UseCases.UseCases.Produtos.NovoProduto
{
    public class NovoProdutoUseCase : INovoProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NovoProdutoUseCase(
            IProdutoRepository produtoRepository,
            IUnitOfWork unitOfWork)
        {
            _produtoRepository = produtoRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Produto> Execute(string nome, string descricao, EnumCategoriaProduto categoria, decimal preco) =>
            InserirProduto(new Produto(Guid.NewGuid(),
                nome,
                descricao,
                categoria,
                preco,
                true));

        private async Task<Produto> InserirProduto(Produto produto)
        {
            if (_produtoRepository
                .Listar(q => q.Nome == produto.Nome
                && q.Categoria == produto.Categoria).Any())
            {
                throw new Exception("Produto já existe com esse nome e categoria");
            }

            await _produtoRepository
                 .Incluir(produto)
                 .ConfigureAwait(false);

            await _unitOfWork
                .Save()
                .ConfigureAwait(false);

            return produto;
        }
    }
}
