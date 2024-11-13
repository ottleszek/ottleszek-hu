using Shared.DomainLayer.Entities;

namespace Shared.ApplicationLayer.Repos.Queries
{
    public interface IQueryMapperRepo<TModel, TDto> : IQueryGenericRepo<TModel, TDto>
        where TModel : class, IDbEntity<TModel>, new()
        where TDto : class, IDbEntity<TDto>, new()
    {
    }
}
