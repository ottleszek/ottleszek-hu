using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos.Interfaces;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos
{
    public interface IWrapRepos
    {
        public IAddressQueryRepo addressQueryRepo { get;  }
    }
}
