using SharedApplicationLayer.Assamblers;
using SharedDomainLayer.Entities;
using SharedDomainLayer.Responses;

namespace SharedApplicationLayer.Contracts.Services
{ 
    public interface IBaseMapperService<TModel, TDto, TAssembler>
        where TModel : class, IDbEntity<TModel>, new()
        where TDto : class, new()
        where TAssembler : class, IAssembler<TModel, TDto>
    {
        public Task<List<TModel>> SelectAsync();
        public Task<Response> UpdateAsync(TModel entity);
    }
}
