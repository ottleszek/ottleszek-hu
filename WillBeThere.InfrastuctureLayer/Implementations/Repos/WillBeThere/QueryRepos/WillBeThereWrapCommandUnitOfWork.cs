using Microsoft.EntityFrameworkCore;
using SharedDomainLayer.Repos;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Repos;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.UnifOfWorks;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class WillBeThereWrapCommandUnitOfWork<TDbContext> : WrapperUnitOfWork<TDbContext>, IWillBeThereWrapCommandUnitOfWork where TDbContext : DbContext
    {
        private TDbContext _dbContext;
        public WillBeThereWrapCommandUnitOfWork
            (
                TDbContext dbContext,
                IAddressCommandRepo addressCommandRepo,
                IEditorCommandRepo editorCommandRepo,
                IOrganizationCategoryCommandRepo organizationCategoryCommandRepo,
                IOrganizationEditorCommandRepo organizationEditorCommandRepo,
                IOrganizationProgramCommandRepo organizationProgramCommandRepo,
                IOrganizationCommandRepo organizationCommandRepo,
                IParticipationCommandRepo participationCommandRepo,
                IProgamOwnerCommandRepo progamOwnerCommandRepo,
                IPublicSpaceCommandRepo publicSpaceCommandRepo,
                IRegisteredUserCommandRepo registeredUserCommandRepo
        )
            : base(dbContext, organizationCommandRepo)
        {
            _dbContext = dbContext;
            AddRepository<IAddressCommandRepo, Address>(addressCommandRepo);
            AddRepository<IEditorCommandRepo, Editor>(editorCommandRepo);
            AddRepository<IOrganizationCategoryCommandRepo, OrganizationCategory>(organizationCategoryCommandRepo);
            AddRepository<IOrganizationEditorCommandRepo, OrganizationEditor>(organizationEditorCommandRepo);
            AddRepository<IOrganizationProgramCommandRepo, OrganizationProgram>(organizationProgramCommandRepo);
            AddRepository<IOrganizationCommandRepo, OrganizationEditor>(organizationCommandRepo);
            AddRepository<IParticipationCommandRepo, Participation>(participationCommandRepo);
            AddRepository<IProgamOwnerCommandRepo, ProgramOwner>(progamOwnerCommandRepo);
            AddRepository<IPublicSpaceCommandRepo, PublicSpace>(publicSpaceCommandRepo);
            AddRepository<IRegisteredUserCommandRepo, RegisteredUser>(registeredUserCommandRepo);
        }

        public override IBaseRepo Repository => base.Repository;
        public IAddressCommandRepo AddressCommandRepo => GetRepository<IAddressCommandRepo, Address>() ?? new AddressCommandRepo<TDbContext>(_dbContext);
        public IEditorCommandRepo EditorCommandRepo => GetRepository<IEditorCommandRepo, Editor>() ?? new EditorCommandRepo<TDbContext>(_dbContext);
        public IOrganizationCategoryCommandRepo OrganizationCategoryCommandRepo => GetRepository<IOrganizationCategoryCommandRepo, OrganizationCategory>() ?? new OrganizationCategoryCommandRepo<TDbContext>(_dbContext);
        public IOrganizationEditorCommandRepo OrganizationEditorCommandRepo => GetRepository<IOrganizationEditorCommandRepo, OrganizationEditor>() ?? new OrganizationEditorCommandRepo<TDbContext>(_dbContext);
        public IOrganizationProgramCommandRepo OrganizationProgramCommandRepo => GetRepository<IOrganizationProgramCommandRepo, OrganizationProgram>() ?? new OrganizationProgramCommandRepo<TDbContext>(_dbContext);
        public IOrganizationCommandRepo OrganizationCommandRepo => GetRepository<IOrganizationCommandRepo, Organization>() ?? new OrganizationCommandRepo<TDbContext>(_dbContext);
        public IParticipationCommandRepo ParticipationCommandRepo => GetRepository<IParticipationCommandRepo, Participation>() ?? new ParticipationCommandRepoo<TDbContext>(_dbContext);
        public IProgamOwnerCommandRepo ProgramOwnerCommandRepo => GetRepository<IProgamOwnerCommandRepo, ProgramOwner>() ?? new ProgramOwnerCommandRepo<TDbContext>(_dbContext);
        public IPublicSpaceCommandRepo PublicSpaceCommandRepo => GetRepository<IPublicSpaceCommandRepo, PublicSpace>() ?? new PublicSpaceCommandRepo<TDbContext>(_dbContext);
        public IRegisteredUserCommandRepo RegisteredUserCommandRepo => GetRepository<IRegisteredUserCommandRepo, RegisteredUser>() ?? new RegisteredUserCommandRepo<TDbContext>(_dbContext);
    }
}
