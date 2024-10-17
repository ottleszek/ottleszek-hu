using Microsoft.EntityFrameworkCore;
using SharedApplicationLayer.Repos;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.UnifOfWorks;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class WillBeThereWrapCommandUnitOfWork<TDbContext> : WrapperUnitOfWork<TDbContext>, IWillBeThereWrapCommandUnitOfWork where TDbContext : DbContext
    {
        private TDbContext _dbContext;
        public WillBeThereWrapCommandUnitOfWork
            (
                TDbContext dbContext,
                IBaseAddressCommandRepo addressCommandRepo,
                IBaseEditorCommandRepo editorCommandRepo,
                IBaseOrganizationCategoryCommandRepo organizationCategoryCommandRepo,
                IBaseOrganizationEditorCommandRepo organizationEditorCommandRepo,
                IBaseOrganizationProgramCommandRepo organizationProgramCommandRepo,
                IBaseOrganizationCommandRepo organizationCommandRepo,
                IBaseParticipationCommandRepo participationCommandRepo,
                IBaseProgamOwnerCommandRepo progamOwnerCommandRepo,
                IBasePublicSpaceCommandRepo publicSpaceCommandRepo,
                IBaseRegisteredUserCommandRepo registeredUserCommandRepo
        )
            : base(dbContext, organizationCommandRepo)
        {
            _dbContext = dbContext;
            AddRepository<IBaseAddressCommandRepo, Address>(addressCommandRepo);
            AddRepository<IBaseEditorCommandRepo, Editor>(editorCommandRepo);
            AddRepository<IBaseOrganizationCategoryCommandRepo, OrganizationCategory>(organizationCategoryCommandRepo);
            AddRepository<IBaseOrganizationEditorCommandRepo, OrganizationEditor>(organizationEditorCommandRepo);
            AddRepository<IBaseOrganizationProgramCommandRepo, OrganizationProgram>(organizationProgramCommandRepo);
            AddRepository<IBaseOrganizationCommandRepo, OrganizationEditor>(organizationCommandRepo);
            AddRepository<IBaseParticipationCommandRepo, Participation>(participationCommandRepo);
            AddRepository<IBaseProgamOwnerCommandRepo, ProgramOwner>(progamOwnerCommandRepo);
            AddRepository<IBasePublicSpaceCommandRepo, PublicSpace>(publicSpaceCommandRepo);
            AddRepository<IBaseRegisteredUserCommandRepo, RegisteredUser>(registeredUserCommandRepo);
        }

        //public override IBaseRepo Repository => base.Repository;
        public IBaseAddressCommandRepo AddressCommandRepo => GetRepository<IBaseAddressCommandRepo, Address>() ?? new AddressCommandRepo<TDbContext>(_dbContext);
        public IBaseEditorCommandRepo EditorCommandRepo => GetRepository<IBaseEditorCommandRepo, Editor>() ?? new EditorCommandRepo<TDbContext>(_dbContext);
        public IBaseOrganizationCategoryCommandRepo OrganizationCategoryCommandRepo => GetRepository<IBaseOrganizationCategoryCommandRepo, OrganizationCategory>() ?? new OrganizationCategoryCommandRepo<TDbContext>(_dbContext);
        public IBaseOrganizationEditorCommandRepo OrganizationEditorCommandRepo => GetRepository<IBaseOrganizationEditorCommandRepo, OrganizationEditor>() ?? new OrganizationEditorCommandRepo<TDbContext>(_dbContext);
        public IBaseOrganizationProgramCommandRepo OrganizationProgramCommandRepo => GetRepository<IBaseOrganizationProgramCommandRepo, OrganizationProgram>() ?? new OrganizationProgramCommandRepo<TDbContext>(_dbContext);
        public IBaseOrganizationCommandRepo OrganizationCommandRepo => GetRepository<IBaseOrganizationCommandRepo, Organization>() ?? new OrganizationCommandRepo<TDbContext>(_dbContext);
        public IBaseParticipationCommandRepo ParticipationCommandRepo => GetRepository<IBaseParticipationCommandRepo, Participation>() ?? new ParticipationCommandRepoo<TDbContext>(_dbContext);
        public IBaseProgamOwnerCommandRepo ProgramOwnerCommandRepo => GetRepository<IBaseProgamOwnerCommandRepo, ProgramOwner>() ?? new ProgramOwnerCommandRepo<TDbContext>(_dbContext);
        public IBasePublicSpaceCommandRepo PublicSpaceCommandRepo => GetRepository<IBasePublicSpaceCommandRepo, PublicSpace>() ?? new PublicSpaceCommandRepo<TDbContext>(_dbContext);
        public IBaseRegisteredUserCommandRepo RegisteredUserCommandRepo => GetRepository<IBaseRegisteredUserCommandRepo, RegisteredUser>() ?? new RegisteredUserCommandRepo<TDbContext>(_dbContext);
    }
}
