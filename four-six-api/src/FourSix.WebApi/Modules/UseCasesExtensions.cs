using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Produtos.AlteraProduto;
using FourSix.UseCases.UseCases.Produtos.InativaProduto;
using FourSix.UseCases.UseCases.Produtos.NovoProduto;
using FourSix.UseCases.UseCases.Produtos.ObtemProduto;
using FourSix.UseCases.UseCases.Produtos.ObtemProdutoPorCategoria;
using FourSix.UseCases.UseCases.Produtos.ObtemProdutos;

namespace FourSix.WebApi.Modules
{
    public static class UseCasesExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<Notification, Notification>();

            #region [ Produtos ]
            services.AddScoped<IAlteraProdutoUseCase, AlteraProdutoUseCase>();
            services.AddScoped<INovoProdutoUseCase, NovoProdutoUseCase>();
            services.AddScoped<IInativaProdutoUseCase, InativaProdutoUseCase>();
            services.AddScoped<IObtemProdutoUseCase, ObtemProdutoUseCase>();
            services.AddScoped<IObtemProdutosPorCategoriaUseCase, ObtemProdutosPorCategoriaUseCase>();
            services.AddScoped<IObtemProdutosUseCase, ObtemProdutosUseCase>();
            #endregion

            return services;
        }
    }
}
