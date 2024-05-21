using FourSix.Controllers.ViewModels;
using FourSix.Domain.Entities.ProdutoAggregate;
using FourSix.UseCases.UseCases.Produtos.ObtemProdutoPorCategoria;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.Controllers.Adapters.Produtos.ObtemProdutosPorCategoria
{
    public class ObtemProdutosPorCategoriaAdapter : IObtemProdutosPorCategoriaAdapter
    {
        private readonly IObtemProdutosPorCategoriaUseCase _useCase;

        public ObtemProdutosPorCategoriaAdapter(IObtemProdutosPorCategoriaUseCase useCase)
        {
            this._useCase = useCase;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObtemProdutosPorCategoriaResponse))]
        public async Task<ObtemProdutosPorCategoriaResponse> Obter(EnumCategoriaProduto categoria)
        {
            var lista = await _useCase.Execute(categoria);

            var model = new List<ProdutoModel>();
            lista.ToList().ForEach(f => model.Add(new ProdutoModel(f)));

            return new ObtemProdutosPorCategoriaResponse(model);
        }
    }
}
