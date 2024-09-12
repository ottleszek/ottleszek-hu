using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Queries;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere
{
    public interface IParticipationRepo : IBaseRepo, IIncludedQueryRepo
    {
    }
}
