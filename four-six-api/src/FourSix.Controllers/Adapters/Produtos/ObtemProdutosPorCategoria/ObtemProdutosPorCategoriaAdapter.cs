using FourSix.Controllers.Presenters;
using FourSix.Controllers.ViewModels;
using FourSix.Domain.Entities.ProdutoAggregate;
using FourSix.UseCases.UseCases.Produtos.ObtemProdutoPorCategoria;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.Controllers.Adapters.Produtos.ObtemProdutosPorCategoria
{
    public class ObtemProdutosPorCategoriaAdapter : IObtemProdutosPorCategoriaAdapter
    {
        private readonly Notification _notification;
        private readonly IObtemProdutosPorCategoriaUseCase _useCase;

        public ObtemProdutosPorCategoriaAdapter(Notification notification,
            IObtemProdutosPorCategoriaUseCase useCase)
        {
            this._useCase = useCase;
            this._notification = notification;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObtemProdutosPorCategoriaResponse))]
        public async Task<ObtemProdutosPorCategoriaResponse> Obter(EnumCategoriaProduto categoria)
        {
            await _useCase.Execute(categoria)
                .ConfigureAwait(false);

            var lista = await _useCase.Execute(categoria);

            var model = new List<ProdutoModel>();
            lista.ToList().ForEach(f => model.Add(new ProdutoModel(f)));

            return new ObtemProdutosPorCategoriaResponse(model);
        }
    }
}
