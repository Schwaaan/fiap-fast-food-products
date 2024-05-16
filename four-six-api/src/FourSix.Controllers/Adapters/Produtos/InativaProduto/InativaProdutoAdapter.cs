using FourSix.Controllers.Adapters.Produtos.AlteraProduto;
using FourSix.Controllers.Presenters;
using FourSix.Controllers.ViewModels;
using FourSix.UseCases.UseCases.Produtos.InativaProduto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.Controllers.Adapters.Produtos.InativaProduto
{
    public class InativaProdutoAdapter : IInativaProdutoAdapter
    {
        private readonly Notification _notification;

        private readonly IInativaProdutoUseCase _useCase;

        public InativaProdutoAdapter(Notification notification,
            IInativaProdutoUseCase useCase)
        {
            this._useCase = useCase;
            this._notification = notification;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AlteraProdutoResponse))]
        public async Task<InativaProdutoResponse> Inativar(Guid id)
        {
            var model = new ProdutoModel(await _useCase.Execute(id));

            return new InativaProdutoResponse(model);
        }
    }
}
