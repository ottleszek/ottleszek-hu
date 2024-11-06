using WillBeThere.ApplicationLayer.Repos.QueryRepo;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.WillBeThere.Backend;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.WrapRepo
{
    public interface IWillBeThereWrapQueryUnitOfWork
    {
        public IAddressDbQueryRepo AddressDbQueryRepo { get; }
        public IEditorDbQueryRepo EditorDbQueryRepo { get; }
        public IOrganizationCategoryDbQueryRepo OrganizationCategoryDbQueryRepo { get; }
        public IOrganizationEditorDbQueryRepo OrganizationEditorDbQueryRepo { get; }
        public IOrganizationProgramDbQueryRepo OrganizationProgramDbQueryRepo { get; }
        public IOrganizationDbQueryRepo OrganizationDbQueryRepo { get; }
        public IParticipationDbQueryRepo ParticipationDbQueryRepo { get; }
        public IProgamOwnerDbQueryRepo ProgramOwnerDbQueryRepo { get; }
        public IPublicSpaceDbQueryRepo PublicSpaceDbQueryRepo { get; }
        public IRegisteredUserDbQueryRepo RegisteredUserDbQueryRepo { get; }
    }
}
