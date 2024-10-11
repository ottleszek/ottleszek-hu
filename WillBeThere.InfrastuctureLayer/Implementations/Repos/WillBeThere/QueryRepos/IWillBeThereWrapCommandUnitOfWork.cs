using WillBeThere.ApplicationLayer.Repos.Base;
using WillBeThere.DomainLayer.Repos.Base;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public interface IWillBeThereWrapCommandUnitOfWork
    {
        public IBaseAddressCommandRepo AddressCommandRepo { get; }
        public IBaseEditorCommandRepo EditorCommandRepo { get; }
        public IBaseOrganizationCategoryCommandRepo OrganizationCategoryCommandRepo { get; }
        public IBaseOrganizationEditorCommandRepo OrganizationEditorCommandRepo { get; }
        public IBaseOrganizationProgramCommandRepo OrganizationProgramCommandRepo { get; }
        public IBaseOrganizationCommandRepo OrganizationCommandRepo { get; }
        public IBaseParticipationCommandRepo ParticipationCommandRepo { get; }
        public IBaseProgamOwnerCommandRepo ProgramOwnerCommandRepo { get; }
        public IBasePublicSpaceCommandRepo PublicSpaceCommandRepo { get; }
        public IBaseRegisteredUserCommandRepo RegisteredUserCommandRepo { get; }
    }
}
