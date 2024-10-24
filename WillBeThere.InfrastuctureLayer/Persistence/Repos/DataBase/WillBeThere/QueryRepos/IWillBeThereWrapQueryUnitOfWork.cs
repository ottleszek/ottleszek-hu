using WillBeThere.ApplicationLayer.Repos.QueryRepo;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos
{
    public interface IWillBeThereWrapQueryUnitOfWork
    {
        public IAddressQueryRepo AddressQueryRepo { get; }
        public IEditorQueryRepo EditorQueryRepo { get; }
        public IOrganizationCategoryQueryRepo OrganizationCategoryQueryRepo { get; }
        public IOrganizationEditorQueryRepo OrganizationEditorQueryRepo { get; }
        public IOrganizationProgramQueryRepo OrganizationProgramQueryRepo { get; }
        public IOrganizationQueryRepo OrganizationQueryRepo { get; }
        public IParticipationQueryRepo ParticipationQueryRepo { get; }
        public IProgamOwnerQueryRepo ProgramOwnerQueryRepo { get; }
        public IPublicSpaceQueryRepo PublicSpaceQueryRepo { get; }
        public IRegisteredUserQueryRepo RegisteredUserQueryRepo { get; }
    }
}
