using Shared.ApplicationLayer.Repos.Queries;
using Shared.ApplicationLayer.Transformers;
using Shared.DomainLayer.Entities;

namespace Shared.InfrastuctureLayer.Persistence.Repos.MapperRepo
{
    public class QueryMapperRepo<TModel, TDto> : IQueryMapperRepo<TModel, TDto>
        where TModel : class, IDbEntity<TModel>, new()
        where TDto : class, IDbEntity<TDto>, new()
    {
        protected readonly IQueryGenericMethodRepo? _repo;
        protected readonly IAssembler<TModel, TDto>? _assambler;

        public QueryMapperRepo(IQueryGenericMethodRepo? baseHttpRepo, IAssembler<TModel, TDto>? assambler)
        {
            _repo = baseHttpRepo;
            _assambler = assambler;
        }

        public Task<TModel?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExsistAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TModel>> GetAllAsync()
        {
            if (_repo is not null && _assambler is not null)
            {
                List<TDto> entityDtos = await _repo.GetAllAsync<TDto>();
                List<TModel> result = entityDtos.Select(entityDto => _assambler.ToModel(entityDto)).ToList();
                return result;
            }
            return new List<TModel>();
        }
    }
}
