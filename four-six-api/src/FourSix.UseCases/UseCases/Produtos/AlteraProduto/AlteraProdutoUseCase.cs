using FourSix.Domain.Entities.ProdutoAggregate;
using FourSix.UseCases.Interfaces;

namespace FourSix.UseCases.UseCases.Produtos.AlteraProduto
{
    public class AlteraProdutoUseCase : IAlteraProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AlteraProdutoUseCase(
            IProdutoRepository produtoRepository,
            IUnitOfWork unitOfWork)
        {
            _produtoRepository = produtoRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Produto> Execute(Guid produtoId, string nome, string descricao, EnumCategoriaProduto categoria, decimal preco) =>
            AlterarProduto(
                new Produto(produtoId,
                    nome,
                    descricao,
                    categoria,
                    preco,
                    true));

        private async Task<Produto> AlterarProduto(Produto produto)
        {
            if (_produtoRepository
                .Listar(q => q.Id != produto.Id && q.Nome == produto.Nome
                && q.Categoria == produto.Categoria).Any())
            {
                throw new Exception("Produto já existe com esse nome e categoria");
            }

            await _produtoRepository
                 .Alterar(produto)
                 .ConfigureAwait(false);

            await _unitOfWork
                .Save()
            .ConfigureAwait(false);

            produto = _produtoRepository.Listar(q => q.Id == produto.Id).FirstOrDefault();

            return produto;
        }
    }
}
