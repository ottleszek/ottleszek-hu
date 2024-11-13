using Shared.ApplicationLayer.Repos.Commands;
using Shared.DomainLayer.Entities;
using Shared.DomainLayer.Responses;

namespace Shared.InfrastuctureLayer.Repos.ModelRepo
{
    public class CommandModelRepo<TModel, TDto> : ICommandGenericRepo<TModel, TDto>
           where TModel : class, IDbEntity<TModel>, new()
           where TDto : class, IDbEntity<TDto>, new()
    {
        protected ICommandMapperRepo<TModel, TDto>? _mapperRepo;


        public CommandModelRepo(ICommandMapperRepo<TModel, TDto>? mapperRepo)
        {
            _mapperRepo = mapperRepo;

        }

        public Task<Response> DeleteAsync(TModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<Response> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> InsertAsync(TModel entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> UpdateAsync(TModel entity)
        {
            return await (_mapperRepo?.UpdateAsync(entity) ?? Task.FromResult(new Response()));
        }
    }
}