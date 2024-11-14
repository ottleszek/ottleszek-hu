using Shared.DomainLayer.Entities;
using Shared.DomainLayer.Responses;
using Shared.ApplicationLayer.Transformers;
using Shared.ApplicationLayer.Persistence;

namespace WillBeThere.InfrastuctureLayer.Adapters.Services
{
    public class ManyDataGenericHttpPersistenceService<TEntity, TDto> : IManyDataPersistenceService<TEntity>
        where TEntity : class, IDbEntity<TEntity>, new()
        where TDto : class, IDbEntity<TDto>, new()
    {
        protected readonly IDomainDtoConterter<TEntity, TDto> _converter;
        protected readonly IManyDataPersistenceService _httpPersistenceService;


        public ManyDataGenericHttpPersistenceService(IManyDataPersistenceService? httpPersistenceService, IDomainDtoConterter<TEntity, TDto>? converter)
        {
            _converter = converter ?? throw new ArgumentNullException(nameof(converter));
            _httpPersistenceService = httpPersistenceService ?? throw new ArgumentNullException(nameof(httpPersistenceService));
        }

        public async Task<Response> UpdateMany(List<TEntity> entities)
        {
            return await _httpPersistenceService.UpdateMany(_converter.ToDto(entities));
        }
    }
}
