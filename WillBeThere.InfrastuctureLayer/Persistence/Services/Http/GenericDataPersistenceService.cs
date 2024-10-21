using SharedDomainLayer.Responses;
using SharedApplicationLayer.Contracts.Persistence;
using SharedDomainLayer.Entities;
using SharedApplicationLayer.Transformers;
using WillBeThere.InfrastuctureLayer.Persistence.Services.DataBase;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.Http
{
    public class GenericDataPersistenceService<TEntity,TDto, TConverter> : IDataPersistenceService<TEntity>
        where TEntity : class, IDbEntity<TEntity>, new()
        where TDto : class, IDbEntity<TDto>, new()
        where TConverter : class, IDomainDtoConterter<TEntity, TDto>
    {
        protected readonly HttpClient? _httpClient;
        protected readonly TConverter? _converter;
        protected readonly IHttpPersistenceService? _httpPersistenceService;


        public GenericDataPersistenceService(IHttpClientFactory? httpClientFactory, IHttpPersistenceService? httpPersistenceService, TConverter? converter)
        {
            if (httpClientFactory is not null)
            {
                _httpClient = httpClientFactory.CreateClient("WillBeThere");
            }
            _converter = converter ?? throw new ArgumentNullException(nameof(converter));
            _httpPersistenceService = httpPersistenceService ?? throw new ArgumentNullException(nameof(httpPersistenceService));
        }

        public async Task<Response> UpdateMany(List<TEntity> entities)
        {
            Response response = new();
            if (_converter is null || _httpPersistenceService is null)
            {
                response.Append($"{nameof(DbDataPersistenceService)} osztály, {nameof(IDataPersistenceService.UpdateMany)} metódusban hiba keletkezett!");
                response.Append($"{entities.Count} db {nameof(TEntity)} objektum hozzáadása az adatbázishoz nem sikerült!");
                return new Response("Több adat együttes mentése nem sikerült.");
            }
            else
            {
                List<TDto> dtos = _converter.ToDto(entities);                
                return await _httpPersistenceService.UpdateMany<TDto>(dtos);
            }
        }
    }
}
