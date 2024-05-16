using FourSix.Controllers.Adapters.Produtos.AlteraProduto;
using FourSix.Controllers.Adapters.Produtos.InativaProduto;
using FourSix.Controllers.Adapters.Produtos.NovoProduto;
using FourSix.Controllers.Adapters.Produtos.ObtemProduto;
using FourSix.Controllers.Adapters.Produtos.ObtemProdutos;
using FourSix.Controllers.Adapters.Produtos.ObtemProdutosPorCategoria;

namespace FourSix.WebApi.Modules
{
    public static class AdaptersExtensions
    {
        public static IServiceCollection AddAdapters(this IServiceCollection services)
        {
            #region [ Produtos ]
            services.AddScoped<IAlteraProdutoAdapter, AlteraProdutoAdapter>();
            services.AddScoped<IInativaProdutoAdapter, InativaProdutoAdapter>();
            services.AddScoped<INovoProdutoAdapter, NovoProdutoAdapter>();
            services.AddScoped<IObtemProdutoAdapter, ObtemProdutoAdapter>();
            services.AddScoped<IObtemProdutosPorCategoriaAdapter, ObtemProdutosPorCategoriaAdapter>();
            services.AddScoped<IObtemProdutosAdapter, ObtemProdutosAdapter>();
            #endregion

            return services;
        }
    }
}
