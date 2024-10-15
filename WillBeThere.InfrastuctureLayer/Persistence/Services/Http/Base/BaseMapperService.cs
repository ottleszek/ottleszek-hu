using SharedApplicationLayer.Transformers;
using SharedApplicationLayer.Contracts.Services;
using SharedDomainLayer.Entities;
using SharedDomainLayer.Responses;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base
{
    public class BaseMapperService<TModel, TDto, TAssembler> : IBaseMapperService<TModel, TDto, TAssembler>
        where TModel : class, IDbEntity<TModel>, new()
        where TDto : class, IDbEntity<TDto>, new()
        where TAssembler : class, IAssembler<TModel, TDto>
    {
        protected readonly IBaseHttpService? _baseHttpService;
        protected readonly TAssembler? _assambler;

        public BaseMapperService() { }

        public BaseMapperService(IBaseHttpService? baseHttpService, TAssembler? assambler)
        {
            _baseHttpService = baseHttpService;
            _assambler = assambler;
        }
        public async Task<List<TModel>> SelectAsync()
        {
            if (_baseHttpService is not null && _assambler is not null)
            {
                List<TDto> entityDtos = await _baseHttpService.SelectAllAsync<TDto>();
                List<TModel> result = entityDtos.Select(entityDto => _assambler.ToModel(entityDto)).ToList();
                return result;
            }
            return new List<TModel>();
        }

        public async Task<Response> UpdateAsync(TModel entity)
        {
            if (_baseHttpService is not null && _assambler is not null)
            {
                Response response = await _baseHttpService.UpdateAsync<TDto>(_assambler.ToDto(entity));
                return response;
            }
            return new Response();
        }
    }
}
