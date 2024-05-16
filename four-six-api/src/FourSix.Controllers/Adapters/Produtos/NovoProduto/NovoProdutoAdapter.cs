using FourSix.Controllers.Presenters;
using FourSix.Controllers.ViewModels;
using FourSix.UseCases.UseCases.Produtos.NovoProduto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.Controllers.Adapters.Produtos.NovoProduto
{
    public class NovoProdutoAdapter : INovoProdutoAdapter
    {
        private readonly Notification _notification;
        private readonly INovoProdutoUseCase _useCase;

        public NovoProdutoAdapter(Notification notification,
            INovoProdutoUseCase useCase)
        {
            this._useCase = useCase;
            this._notification = notification;
        }

        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(NovoProdutoResponse))]
        public async Task<NovoProdutoResponse> Inserir(NovoProdutoRequest produto)
        {
            var model = new ProdutoModel(await _useCase.Execute(produto.Nome, produto.Descricao, produto.Categoria, produto.Preco));

            return new NovoProdutoResponse(model);
        }
    }
}

