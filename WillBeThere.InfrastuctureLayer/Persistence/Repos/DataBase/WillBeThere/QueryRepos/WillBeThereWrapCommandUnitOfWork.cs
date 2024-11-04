using Microsoft.EntityFrameworkCore;
using WillBeThere.ApplicationLayer.Contracts.UnitOfWork;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.UnifOfWorks;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos
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
        public IBaseAddressCommandRepo AddressCommandRepo => GetRepository<IBaseAddressCommandRepo, Address>() ?? new AddressDbCommandRepo<TDbContext>(_dbContext);
        public IBaseEditorCommandRepo EditorCommandRepo => GetRepository<IBaseEditorCommandRepo, Editor>() ?? new EditorDbCommandRepo<TDbContext>(_dbContext);
        public IBaseOrganizationCategoryCommandRepo OrganizationCategoryCommandRepo => GetRepository<IBaseOrganizationCategoryCommandRepo, OrganizationCategory>() ?? new OrganizationDbCategoryCommandRepo<TDbContext>(_dbContext);
        public IBaseOrganizationEditorCommandRepo OrganizationEditorCommandRepo => GetRepository<IBaseOrganizationEditorCommandRepo, OrganizationEditor>() ?? new OrganizationEditorDbCommandRepo<TDbContext>(_dbContext);
        public IBaseOrganizationProgramCommandRepo OrganizationProgramCommandRepo => GetRepository<IBaseOrganizationProgramCommandRepo, OrganizationProgram>() ?? new OrganizationProgramDbCommandRepo<TDbContext>(_dbContext);
        public IBaseOrganizationCommandRepo OrganizationCommandRepo => GetRepository<IBaseOrganizationCommandRepo, Organization>() ?? new OrganizationDbCommandRepo<TDbContext>(_dbContext);
        public IBaseParticipationCommandRepo ParticipationCommandRepo => GetRepository<IBaseParticipationCommandRepo, Participation>() ?? new ParticipationCommandDbRepoo<TDbContext>(_dbContext);
        public IBaseProgamOwnerCommandRepo ProgramOwnerCommandRepo => GetRepository<IBaseProgamOwnerCommandRepo, ProgramOwner>() ?? new ProgramOwnerDbCommandRepo<TDbContext>(_dbContext);
        public IBasePublicSpaceCommandRepo PublicSpaceCommandRepo => GetRepository<IBasePublicSpaceCommandRepo, PublicSpace>() ?? new PublicSpaceDbCommandRepo<TDbContext>(_dbContext);
        public IBaseRegisteredUserCommandRepo RegisteredUserCommandRepo => GetRepository<IBaseRegisteredUserCommandRepo, RegisteredUser>() ?? new RegisteredUserDbCommandRepo<TDbContext>(_dbContext);
    }
}
