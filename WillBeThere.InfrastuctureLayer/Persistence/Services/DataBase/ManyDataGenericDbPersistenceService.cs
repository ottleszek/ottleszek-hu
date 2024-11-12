using Shared.DomainLayer.Entities;
using Shared.DomainLayer.Responses;
using Shared.ApplicationLayer.Persistence;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services
{
    public class ManyDataGenericDbPersistenceService<TEntity, TDto> : IManyDataPersistenceService<TEntity>
        where TEntity : class, IDbEntity<TEntity>, new()
        where TDto : class, IDbEntity<TDto>, new()
    {
        protected readonly IManyDataPersistenceService? _httpPersistenceService;


        public ManyDataGenericDbPersistenceService(IManyDataPersistenceService? httpPersistenceService)
        {
            _httpPersistenceService = httpPersistenceService ?? throw new ArgumentNullException(nameof(httpPersistenceService));
        }

        public async Task<Response> UpdateMany(List<TEntity> entities)
        {
            Response response = new();
            if (_httpPersistenceService is null)
            {
                response.Append($"{nameof(ManyDataGenericDbPersistenceService<TEntity, TDto>)} osztály, {nameof(IManyDataPersistenceService.UpdateMany)} metódusban hiba keletkezett!");
                response.Append($"{entities.Count} db {nameof(TEntity)} objektum hozzáadása az adatbázishoz nem sikerült!");
                return new Response("Több adat együttes mentése nem sikerült.");
            }
            else
            {
                return await _httpPersistenceService.UpdateMany(entities);
            }
        }
    }
}
