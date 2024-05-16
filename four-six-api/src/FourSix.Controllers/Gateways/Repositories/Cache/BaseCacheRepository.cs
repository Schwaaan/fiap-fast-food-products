using FourSix.Controllers.Extensions;
using FourSix.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace FourSix.Controllers.Gateways.Repositories.Cache
{
    public class BaseCacheRepository<T, C> : BaseRepository<T, C> where T : class, IBaseEntity
    {
        private readonly IDistributedCache _distributedCache;
        private readonly DistributedCacheEntryOptions _slidingExpiration;

        public BaseCacheRepository(DbContext context, IDistributedCache distributedCache) : base(context)
        {
            _distributedCache = distributedCache;

            _slidingExpiration = new DistributedCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(5)
            };
        }

        public override T Obter(C id)
        {
            T entidade = null;

            string? value = _distributedCache.GetString(id.ToString());
            if (value is not null)
            {
                entidade = JsonConvert.DeserializeObject<T>(value, new JsonSerializerSettings()
                {
                    ContractResolver = new JsonSerializerPrivateResolver()
                });

            }

            if (entidade == null)
            {
                entidade = base.Obter(id);
                _distributedCache.SetStringAsync(id.ToString(), JsonConvert.SerializeObject(entidade), _slidingExpiration);
            }

            return entidade;
        }

        public override Task Alterar(T entidade)
        {
            var task = base.Alterar(entidade);

            _distributedCache.Remove(entidade.Id.ToString());

            return task;
        }

        public override Task Excluir(C id)
        {
            var task = base.Excluir(id);

            _distributedCache.Remove(id.ToString());

            return task;
        }
    }
}
