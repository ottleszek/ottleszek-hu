using WillBeThere.Application.Assemblers;
using WillBeThere.Application.Responses;
using WillBeThere.Domain.Entities.DbIds;
using WillBeThere.HttpService.MapperService;

namespace WillBeThere.HttpService.DataService
{
    public class BaseDataService<TEntity, TEntityDto, TAssembler> : IBaseDataService<TEntity,TEntityDto,TAssembler>
        where TEntity : class, IDbEntity<TEntity>, new()
        where TEntityDto : class, new()
        where TAssembler : class, IAssembler<TEntity, TEntityDto>
    {
        protected IBaseMapperService<TEntity,TEntityDto, TAssembler>? _mapperService;


        public BaseDataService(IBaseMapperService<TEntity,TEntityDto, TAssembler>? mapperService)
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
            if (_mapperService is not null)
            {
                return await _mapperService.SelectAsync();
            }
            else { return new List<TEntity>(); }
        }

        public Task<Response> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}