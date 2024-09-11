using WillBeThere.InfrastuctureLayer.DataBrokers;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseRepos;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere
{
    public interface IParticipationRepo : IBaseRepo, IIncludedDataBroker, IRepositoryBase
    {
    }
}
