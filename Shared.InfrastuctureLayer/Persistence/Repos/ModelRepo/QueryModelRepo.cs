using Shared.ApplicationLayer.Repos.Queries;
using Shared.DomainLayer.Entities;


namespace Shared.InfrastuctureLayer.Persistence.Repos.ModelRepo
{
    public class QueryModelRepo<TModel, TDto> : IQueryGenericRepo<TModel, TDto>
           where TModel : class, IDbEntity<TModel>, new()
           where TDto : class, IDbEntity<TDto>, new()
    {
        protected IQueryMapperRepo<TModel, TDto>? _mapperRepo;

        public QueryModelRepo(IQueryMapperRepo<TModel, TDto>? mapperRepo)
        {
            _mapperRepo = mapperRepo;
        }
        public async Task<List<TModel>> GetAllAsync()
        {
            return await (_mapperRepo?.GetAllAsync() ?? Task.FromResult(new List<TModel>()));
        }

        public Task<TModel?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }


        public Task<bool> IsExsistAsync(Guid id)
        {
            throw new NotImplementedException();
        }


    }
}