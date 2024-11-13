using Shared.DomainLayer.Entities;
using Shared.DomainLayer.Responses;
using Shared.ApplicationLayer.Persistence;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services
{
    public class ManyDataGenericDbPersistenceService<TEntity, TDto> : IManyDataPersistenceService<TEntity>
        where TEntity : class, IDbEntity<TEntity>, new()
        where TDto : class, IDbEntity<TDto>, new()
    {
        protected readonly IManyDataPersistenceService _httpPersistenceService;

        public ManyDataGenericDbPersistenceService(IManyDataPersistenceService? httpPersistenceService)
        {
            _httpPersistenceService = httpPersistenceService ?? throw new ArgumentNullException(nameof(httpPersistenceService));
        }

        public async Task<Response> UpdateMany(List<TEntity> entities)
        {
            return await _httpPersistenceService.UpdateMany(entities);
        }
    }
}
