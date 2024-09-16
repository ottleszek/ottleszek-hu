using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.DomainLayer.Entities.DbIds;

namespace WillBeThere.ApplicationLayer.Contracts.Services.MapperService
{
    public interface IBaseMapperService<TModel, TDto, TAssembler>
        where TModel : class, IDbEntity<TModel>, new()
        where TDto : class, new()
        where TAssembler : class, IAssembler<TModel, TDto>
    {
        public Task<List<TModel>> SelectAsync();
    }
}
