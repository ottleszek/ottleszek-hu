using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseRepos
{
    public interface IWrapRepo
    {
        public IAddressQueryRepo? AddressRepo { get; }
        public IOrganizationRepo? OrganizationRepo { get; }
        public IOrganizationCategoryRepo? OrganizationCategoryRepo { get; }
        public IOrganizationProgramQueryRepo? OrganizationProgramRepo { get; }
        public IParticipationRepo? ParticipationRepo { get; }
        public IPublicSpaceRepo? PublicSpaceRepo { get; }
        public IRegisteredUserRepo? RegisteredUserRepo { get; }


    }
}
