using FourSix.Controllers.ViewModels;
using FourSix.UseCases.UseCases.Produtos.ObtemProdutos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.Controllers.Adapters.Produtos.ObtemProdutos
{
    public class ObtemProdutosAdapter : IObtemProdutosAdapter
    {
        private readonly IObtemProdutosUseCase _useCase;

        public ObtemProdutosAdapter(IObtemProdutosUseCase useCase)
        {
            this._useCase = useCase;
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
