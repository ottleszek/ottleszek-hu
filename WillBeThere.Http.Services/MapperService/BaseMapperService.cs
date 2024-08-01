using WillBeThere.HttpService.HttpService;
using WillBeThere.Shared.Assemblers;
using WillBeThere.Shared.Models.Guids;

namespace WillBeThere.HttpService.MapperService
{
    public class BaseMapperService<TModel, TDto,TAssembler> : IBaseMapperService<TModel,TDto, TAssembler>
        where TModel : class, IDbEntity<TModel>, new()
        where TDto : class, new()
        where TAssembler : class, IAssembler<TModel,TDto>
    {
        protected readonly IBaseHttpService<TDto>? _baseHttpService;
        protected readonly TAssembler? _assambler;

        public BaseMapperService()
        {            
        }

        public BaseMapperService(IBaseHttpService<TDto>? baseHttpService, TAssembler? assambler)
        {
            _baseHttpService = baseHttpService;
            _assambler = assambler;
        }
        public async Task<List<TModel>> SelectAsync() 
        {
            if (_baseHttpService is not null && _assambler is not null)
            {
                List<TDto> entityDtos = await _baseHttpService.SelectAsync<TModel>();
                List<TModel> result = entityDtos.Select(entityDto => _assambler.ToModel(entityDto)).ToList();
                return result;
            }
            return new List<TModel>();
        }
    }
}
