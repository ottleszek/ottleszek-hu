using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WrapRepos
{
    public interface IWrapCommandRepo
    {
        /* public IAddressQueryRepo? AddressRepo { get; }
         public IOrganizationRepo? OrganizationRepo { get; }
         public IOrganizationCategoryRepo? OrganizationCategoryRepo { get; }*/
        public IOrganizationProgramCommandRepo? OrganizationProgramRepo { get; }
        /*public IParticipationRepo? ParticipationRepo { get; }
        public IPublicSpaceRepo? PublicSpaceRepo { get; }
        public IRegisteredUserRepo? RegisteredUserRepo { get; }*/


    }
}
