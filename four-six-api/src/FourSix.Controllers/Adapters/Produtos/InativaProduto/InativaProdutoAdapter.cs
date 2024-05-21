using FourSix.Controllers.Adapters.Produtos.AlteraProduto;
using FourSix.Controllers.ViewModels;
using FourSix.UseCases.UseCases.Produtos.InativaProduto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.Controllers.Adapters.Produtos.InativaProduto
{
    public class InativaProdutoAdapter : IInativaProdutoAdapter
    {
        private readonly IInativaProdutoUseCase _useCase;

        public InativaProdutoAdapter(IInativaProdutoUseCase useCase)
        {
            this._useCase = useCase;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AlteraProdutoResponse))]
        public async Task<InativaProdutoResponse> Inativar(Guid id)
        {
            var model = new ProdutoModel(await _useCase.Execute(id));

            return new InativaProdutoResponse(model);
        }
    }
}
