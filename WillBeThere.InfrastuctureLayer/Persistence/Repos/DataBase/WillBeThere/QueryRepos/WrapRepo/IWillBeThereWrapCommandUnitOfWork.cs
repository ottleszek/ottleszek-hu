using WillBeThere.ApplicationLayer.Repos.CommandRepo;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.WrapRepo
{
    public interface IWillBeThereWrapCommandUnitOfWork
    {
        public IAddressCommandRepo AddressCommandRepo { get; }
        public IEditorCommandRepo EditorCommandRepo { get; }
        public IOrganizationCategoryCommandRepo OrganizationCategoryCommandRepo { get; }
        public IOrganizationEditorCommandRepo OrganizationEditorCommandRepo { get; }
        public IOrganizationProgramCommandRepo OrganizationProgramCommandRepo { get; }
        public IOrganizationCommandRepo OrganizationCommandRepo { get; }
        public IParticipationCommandRepo ParticipationCommandRepo { get; }
        public IProgamOwnerCommandRepo ProgramOwnerCommandRepo { get; }
        public IPublicSpaceCommandRepo PublicSpaceCommandRepo { get; }
        public IRegisteredUserCommandRepo RegisteredUserCommandRepo { get; }
    }
}
