using Shared.DomainLayer.Entities;

namespace Shared.ApplicationLayer.Repos.Commands
{
    public interface ICommandMapperRepo<TModel, TDto> : ICommandGenericRepo<TModel, TDto>
        where TModel : class, IDbEntity<TModel>, new()
        where TDto : class, IDbEntity<TDto>, new()
    {
    }
}
