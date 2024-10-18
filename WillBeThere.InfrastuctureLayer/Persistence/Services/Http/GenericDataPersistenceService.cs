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
        where TConverter : class, IDomainDtoConterter<TEntity, TDto>, new()
    {
        protected readonly HttpClient? _httpClient;
        protected readonly TConverter? _converter;
        protected readonly IHttpPersistenceService? _httpPersistenceService;

        public GenericDataPersistenceService(TConverter? converter, IHttpPersistenceService httpPersistenceService )
        {
            _httpClient = new HttpClient();
            _converter = converter;
            _httpPersistenceService = httpPersistenceService;
        }
        public GenericDataPersistenceService(IHttpClientFactory? httpClientFactory, IHttpPersistenceService dataPersistenceService, TConverter? converter)
        {
            if (httpClientFactory is not null)
            {
                _httpClient = httpClientFactory.CreateClient("WillBeThere");
            }
            _converter = converter;
            _httpPersistenceService = dataPersistenceService;
        }

        public async Task<Response> SaveMany(List<TEntity> entities)
        {
            Response response = new Response();
            if (_converter is null)
            {
                response.Append($"{nameof(DbDataPersistenceService)} osztály, {nameof(IDataPersistenceService.SaveMany)} metódusban hiba keletkezett!");
                response.Append($"{entities.Count} db {nameof(TEntity)} objektum hozzáadása az adatbázishoz nem sikerült!");
                return new Response("Több adat együttes mentése nem sikerült.");
            }
            else
            {
                List<TDto> dtos = _converter.ToDto(entities);
                return await _httpPersistenceService.SaveMany<TDto>(dtos);
            }
        }
    }
}
