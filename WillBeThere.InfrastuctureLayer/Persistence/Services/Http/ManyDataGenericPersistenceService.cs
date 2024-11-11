using WillBeThere.InfrastuctureLayer.Persistence.Services.DataBase;
using Shared.DomainLayer.Entities;
using Shared.DomainLayer.Responses;
using Shared.ApplicationLayer.Transformers;
using Shared.ApplicationLayer.Persistence;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services
{
    public class ManyDataGenericPersistenceService<TEntity, TDto> : IManyDataPersistenceService<TEntity>
        where TEntity : class, IDbEntity<TEntity>, new()
        where TDto : class, IDbEntity<TDto>, new()
    {
        protected readonly HttpClient? _httpClient;
        protected readonly IDomainDtoConterter<TEntity, TDto>? _converter;
        protected readonly IManyDataPersistenceService? _httpPersistenceService;


        public ManyDataGenericPersistenceService(IManyDataPersistenceService? httpPersistenceService, IDomainDtoConterter<TEntity, TDto> converter)
        {
            _converter = converter ?? throw new ArgumentNullException(nameof(converter));
            _httpPersistenceService = httpPersistenceService ?? throw new ArgumentNullException(nameof(httpPersistenceService));
        }

        public async Task<Response> UpdateMany(List<TEntity> entities)
        {
            Response response = new();
            if (_converter is null || _httpPersistenceService is null)
            {
                response.Append($"{nameof(ManyDataDbPersistenceService)} osztály, {nameof(IManyDataPersistenceService.UpdateMany)} metódusban hiba keletkezett!");
                response.Append($"{entities.Count} db {nameof(TEntity)} objektum hozzáadása az adatbázishoz nem sikerült!");
                return new Response("Több adat együttes mentése nem sikerült.");
            }
            else
            {
                List<TDto> dtos = _converter.ToDto(entities);
                return await _httpPersistenceService.UpdateMany(dtos);
            }
        }
    }
}
