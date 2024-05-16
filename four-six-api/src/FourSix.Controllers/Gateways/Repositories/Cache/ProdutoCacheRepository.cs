using FourSix.Domain.Entities.ProdutoAggregate;
using FourSix.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace FourSix.Controllers.Gateways.Repositories.Cache
{
    public class ProdutoCacheRepository : BaseCacheRepository<Produto, Guid>, IProdutoRepository
    {
        public ProdutoCacheRepository(DbContext context, IDistributedCache distributedCache) : base(context, distributedCache)
        {
        }
    }
}
