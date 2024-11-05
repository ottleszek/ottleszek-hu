using WillBeThere.ApplicationLayer.Contracts.UnitOfWork;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.InfrastuctureLayer.Context;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.UnifOfWorks;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.WillBeThere
{
    public class WillBeThereWrapCommandUnitOfWork<TDbContext> : WrapperUnitOfWork<TDbContext>, IWillBeThereWrapCommandUnitOfWork where TDbContext : WillBeThereContext
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
            : base(dbContext)
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

        //public override IBaseRepo Repository => base.Repository;
        public IAddressCommandRepo AddressCommandRepo => GetRepository<IAddressCommandRepo, Address>() ?? new AddressDbCommandRepo<TDbContext>(_dbContext);
        public IEditorCommandRepo EditorCommandRepo => GetRepository<IEditorCommandRepo, Editor>() ?? new EditorDbCommandRepo<TDbContext>(_dbContext);
        public IOrganizationCategoryCommandRepo OrganizationCategoryCommandRepo => GetRepository<IOrganizationCategoryCommandRepo, OrganizationCategory>() ?? new OrganizationCategoryDbCommandRepo<TDbContext>(_dbContext);
        public IOrganizationEditorCommandRepo OrganizationEditorCommandRepo => GetRepository<IOrganizationEditorCommandRepo, OrganizationEditor>() ?? new OrganizationEditorDbCommandRepo<TDbContext>(_dbContext);
        public IOrganizationProgramCommandRepo OrganizationProgramCommandRepo => GetRepository<IOrganizationProgramCommandRepo, OrganizationProgram>() ?? new OrganizationProgramDbCommandRepo<TDbContext>(_dbContext);
        public IOrganizationCommandRepo OrganizationCommandRepo => GetRepository<IOrganizationCommandRepo, Organization>() ?? new OrganizationDbCommandRepo<TDbContext>(_dbContext);
        public IParticipationCommandRepo ParticipationCommandRepo => GetRepository<IParticipationCommandRepo, Participation>() ?? new ParticipationCommandDbRepoo<TDbContext>(_dbContext);
        public IProgamOwnerCommandRepo ProgramOwnerCommandRepo => GetRepository<IProgamOwnerCommandRepo, ProgramOwner>() ?? new ProgramOwnerDbCommandRepo<TDbContext>(_dbContext);
        public IPublicSpaceCommandRepo PublicSpaceCommandRepo => GetRepository<IPublicSpaceCommandRepo, PublicSpace>() ?? new PublicSpaceDbCommandRepo<TDbContext>(_dbContext);
        public IRegisteredUserCommandRepo RegisteredUserCommandRepo => GetRepository<IRegisteredUserCommandRepo, RegisteredUser>() ?? new RegisteredUserDbCommandRepo<TDbContext>(_dbContext);
    }
}
