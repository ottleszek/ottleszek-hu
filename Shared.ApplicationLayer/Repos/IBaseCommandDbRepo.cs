using Shared.ApplicationLayer.Repos.Commands;

namespace Shared.ApplicationLayer.Repos
{
    public interface IBaseCommandDbRepo : ICommandGenericMethodRepo, IBaseDbRepo
    {
    }
}
