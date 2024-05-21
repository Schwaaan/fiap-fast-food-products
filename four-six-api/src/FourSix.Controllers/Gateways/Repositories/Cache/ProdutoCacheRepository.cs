using FourSix.Domain.Entities.ProdutoAggregate;
using FourSix.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Diagnostics.CodeAnalysis;

namespace FourSix.Controllers.Gateways.Repositories.Cache
{
    [ExcludeFromCodeCoverage]
    public class ProdutoCacheRepository : BaseCacheRepository<Produto, Guid>, IProdutoRepository
    {
        public ProdutoCacheRepository(DbContext context, IDistributedCache distributedCache) : base(context, distributedCache)
        {
        }
    }
}
