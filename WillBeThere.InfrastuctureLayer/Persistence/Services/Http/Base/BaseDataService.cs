using SharedApplicationLayer.Assamblers;
using SharedApplicationLayer.Contracts.Services;
using SharedDomainLayer.Entities;
using SharedDomainLayer.Responses;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base
{
    public class BaseDataService<TEntity, TEntityDto, TAssembler> : IBaseDataService<TEntity, TEntityDto, TAssembler>
           where TEntity : class, IDbEntity<TEntity>, new()
           where TEntityDto : class, new()
           where TAssembler : class, IAssembler<TEntity, TEntityDto>
    {
        protected IBaseMapperService<TEntity, TEntityDto, TAssembler>? _mapperService;


        public BaseDataService(IBaseMapperService<TEntity, TEntityDto, TAssembler>? mapperService)
        {
            _mapperService = mapperService;

        }

        public Task<Response> DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<Response> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> SelectAsync()
        {
            return await (_mapperService?.SelectAsync() ?? Task.FromResult(new List<TEntity>()));
        }

        public async Task<Response> UpdateAsync(TEntity entity)
        {
            return await (_mapperService?.UpdateAsync(entity) ?? Task.FromResult(new Response()));
        }
    }
}