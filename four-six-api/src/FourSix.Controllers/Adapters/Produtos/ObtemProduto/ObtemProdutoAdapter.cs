using FourSix.Controllers.Presenters;
using FourSix.Controllers.ViewModels;
using FourSix.UseCases.UseCases.Produtos.ObtemProduto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.Controllers.Adapters.Produtos.ObtemProduto
{
    public class ObtemProdutoAdapter : IObtemProdutoAdapter
    {
        private readonly Notification _notification;
        private readonly IObtemProdutoUseCase _useCase;

        public ObtemProdutoAdapter(Notification notification,
            IObtemProdutoUseCase useCase)
        {
            this._useCase = useCase;
            this._notification = notification;
        }

        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ObtemProdutoResponse))]
        public async Task<ObtemProdutoResponse> Obter(Guid id)
        {
            var model = new ProdutoModel(await _useCase.Execute(id));

            return new ObtemProdutoResponse(model);
        }
    }
}
