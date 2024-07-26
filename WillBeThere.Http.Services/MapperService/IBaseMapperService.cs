using WillBeThere.Shared.Assemblers;
using WillBeThere.Shared.Models.Guids;

namespace WillBeThere.HttpService.MapperService
{
    public interface IBaseMapperService<TModel, TDto, TAssembler> 
        where TModel : class, IDbEntity<TModel>, new()
        where TDto : class, new()
        where TAssembler : class, IAssembler<TModel, TDto>
    {
        public Task<List<TModel>> SelectAsync();
    }
}
