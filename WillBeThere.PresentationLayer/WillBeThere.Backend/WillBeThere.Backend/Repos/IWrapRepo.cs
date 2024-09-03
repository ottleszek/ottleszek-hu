using WillBeThere.Backend.Repos.WillBeThere;

namespace WillBeThere.Backend.Repos
{
    public interface IWrapRepo
    {
        public IAddressRepo? AddressRepo { get; }
        public IOrganizationRepo? OrganizationRepo { get; }
        public IOrganizationAdminUserRepo? OrganizationAdminUserRepo { get; }
        public IOrganizationCategoryRepo? OrganizationCategoryRepo { get; }
        public IOrganizationProgramRepo? OrganizationProgramRepo { get; }
        public IParticipationRepo? ParticipationRepo { get; }
        public IPublicSpaceRepo? PublicSpaceRepo { get; }
        public IRegisteredUserRepo? RegisteredUserRepo { get; }
        

    }
}
