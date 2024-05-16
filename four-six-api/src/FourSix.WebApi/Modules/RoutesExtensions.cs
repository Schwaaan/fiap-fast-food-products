using FourSix.Controllers.Adapters.Produtos.AlteraProduto;
using FourSix.Controllers.Adapters.Produtos.InativaProduto;
using FourSix.Controllers.Adapters.Produtos.NovoProduto;
using FourSix.Controllers.Adapters.Produtos.ObtemProduto;
using FourSix.Controllers.Adapters.Produtos.ObtemProdutos;
using FourSix.Controllers.Adapters.Produtos.ObtemProdutosPorCategoria;
using FourSix.Domain.Entities.ProdutoAggregate;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.Modules
{
    public static class RoutesExtensions
    {
        public static void AddRoutesMaps(this IEndpointRouteBuilder app)
        {
            #region [ Produtos ]

            app.MapPut("produtos/{produtoId:guid}",
            [SwaggerOperation(Summary = "Altera produto")]
            ([SwaggerParameter("Id do produto")] Guid produtoId, [FromBody] AlteraProdutoRequest request, IAlteraProdutoAdapter adapter) =>
            {
                return adapter.Alterar(produtoId, request);
            }).WithTags("Produtos").AllowAnonymous(); ;

            app.MapDelete("produtos/{produtoId:guid}",
            [SwaggerOperation(Summary = "Inativa produto")]
            ([SwaggerParameter("Id do produto")] Guid produtoId, IInativaProdutoAdapter adapter) =>
            {
                return adapter.Inativar(produtoId);
            }).WithTags("Produtos").AllowAnonymous(); ;

            app.MapPost("produtos",
            [SwaggerOperation(Summary = "Insere novo produto")]
            ([FromBody] NovoProdutoRequest request, INovoProdutoAdapter adapter) =>
            {
                return adapter.Inserir(request);
            }).WithTags("Produtos").AllowAnonymous(); ;

            app.MapGet("produtos/{produtoId:guid}",
            [SwaggerOperation(Summary = "Obtém o produto")]
            ([SwaggerParameter("Id do produto")] Guid produtoId, IObtemProdutoAdapter adapter) =>
            {
                return adapter.Obter(produtoId);
            }).WithTags("Produtos").AllowAnonymous(); ;

            app.MapGet("produtos/{categoria}",
            [SwaggerOperation(Summary = "Obtém o produto por categoria")]
            ([SwaggerParameter("Categoria do produto<br><br>Lanche = 1<br>Acompanhamento = 2<br>Sobremesa = 3<br>Bebida = 4")] EnumCategoriaProduto categoria, IObtemProdutosPorCategoriaAdapter adapter) =>
            {
                return adapter.Obter(categoria);
            }).WithTags("Produtos").AllowAnonymous(); ;

            app.MapGet("produtos",
            [SwaggerOperation(Summary = "Lista os produto")]
            (IObtemProdutosAdapter adapter) =>
            {
                return adapter.Listar();
            }).WithTags("Produtos").AllowAnonymous(); ;

            #endregion
        }
    }
}
