using Shared.ApplicationLayer.Repos.Commands;
using Shared.ApplicationLayer.Transformers;
using Shared.DomainLayer.Entities;
using Shared.DomainLayer.Responses;

namespace Shared.InfrastuctureLayer.Repos.MapperRepo
{
    public class CommandMapperRepo<TModel, TDto> : ICommandMapperRepo<TModel, TDto>
        where TModel : class, IDbEntity<TModel>, new()
        where TDto : class, IDbEntity<TDto>, new()
    {
        protected readonly ICommandGenericMethodRepo? _repo;
        protected readonly IAssembler<TModel, TDto>? _assambler;

        public CommandMapperRepo() { }

        public CommandMapperRepo(ICommandGenericMethodRepo? repo, IAssembler<TModel, TDto>? assambler)
        {
            _repo = repo;
            _assambler = assambler;
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
            if (_repo is not null && _assambler is not null)
            {
                Response response = await _repo.UpdateAsync<TDto>(_assambler.ToDto(entity));
                return response;
            }
            return new Response();
        }
    }
}
