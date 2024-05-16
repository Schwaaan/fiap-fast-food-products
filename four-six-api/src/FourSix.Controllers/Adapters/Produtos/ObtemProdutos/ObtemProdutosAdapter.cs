using FourSix.Controllers.Presenters;
using FourSix.Controllers.ViewModels;
using FourSix.UseCases.UseCases.Produtos.ObtemProdutos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.Controllers.Adapters.Produtos.ObtemProdutos
{
    public class ObtemProdutosAdapter : IObtemProdutosAdapter
    {
        private readonly Notification _notification;

        private readonly IObtemProdutosUseCase _useCase;

        public ObtemProdutosAdapter(Notification notification,
            IObtemProdutosUseCase useCase)
        {
            this._useCase = useCase;
            this._notification = notification;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObtemProdutosResponse))]
        public async Task<ObtemProdutosResponse> Listar()
        {
            var lista = await _useCase.Execute();

            var model = new List<ProdutoModel>();
            lista.ToList().ForEach(f => model.Add(new ProdutoModel(f)));

            return new ObtemProdutosResponse(model);
        }
    }
}
