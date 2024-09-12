using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseRepos
{
    public interface IWrapRepo
    {
        public IAddressQueryRepo? AddressRepo { get; }
        public IOrganizationRepo? OrganizationRepo { get; }
        public IOrganizationAdminUserRepo? OrganizationAdminUserRepo { get; }
        public IOrganizationCategoryRepo? OrganizationCategoryRepo { get; }
        public IOrganizationProgramRepo? OrganizationProgramRepo { get; }
        public IParticipationRepo? ParticipationRepo { get; }
        public IPublicSpaceRepo? PublicSpaceRepo { get; }
        public IRegisteredUserRepo? RegisteredUserRepo { get; }


    }
}
