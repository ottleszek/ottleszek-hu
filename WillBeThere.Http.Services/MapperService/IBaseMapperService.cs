using WillBeThere.Application.Assemblers;
using WillBeThere.Domain.Entities.DbIds;

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
