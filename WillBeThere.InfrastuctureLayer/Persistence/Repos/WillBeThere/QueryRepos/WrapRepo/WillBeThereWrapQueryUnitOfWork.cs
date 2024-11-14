using WillBeThere.ApplicationLayer.Repos.QueryRepo;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.InfrastuctureLayer.Context;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.WillBeThere;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.WillBeThere.Backend;
using WillBeThere.InfrastuctureLayer.Persistence.UnifOfWorks;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.WrapRepo
{
    public class WillBeThereWrapQueryUnitOfWork<TDbContext> : WrapperQueryUnitOfWork<TDbContext>, IWillBeThereWrapQueryUnitOfWork where TDbContext : WillBeThereContext
    {
        private TDbContext dbContext;
        public WillBeThereWrapQueryUnitOfWork
            (
                TDbContext dbContext,
                IAddressDbQueryRepo addressDbQueryRepo,
                IEditorDbQueryRepo editorDbQueryRepo,
                IOrganizationCategoryDbQueryRepo organizationDbCategoryQueryRepo,
                IOrganizationEditorDbQueryRepo organizationDbEditorQueryRepo,
                IOrganizationProgramDbQueryRepo organizationDbProgramQueryRepo,
                IOrganizationDbQueryRepo organizationQueryDbRepo,
                IParticipationDbQueryRepo participationDbQueryRepo,
                IProgamOwnerDbQueryRepo progamOwnerDbQueryRepo,
                IPublicSpaceDbQueryRepo publicSpaceDbQueryRepo,
                IRegisteredUserDbQueryRepo registeredUserDbQueryRepo
            )
            : base(dbContext)
        {
            this.dbContext = dbContext;
            AddRepository<IAddressQueryRepo, Address>(addressDbQueryRepo);
            AddRepository<IEditorQueryRepo, Editor>(editorDbQueryRepo);
            AddRepository<IOrganizationCategoryQueryRepo, OrganizationCategory>(organizationDbCategoryQueryRepo);
            AddRepository<IOrganizationEditorQueryRepo, OrganizationEditor>(organizationDbEditorQueryRepo);
            AddRepository<IOrganizationProgramQueryRepo, OrganizationProgram>(organizationDbProgramQueryRepo);
            AddRepository<IOrganizationQueryRepo, Organization>(organizationQueryDbRepo);
            AddRepository<IParticipationQueryRepo, Participation>(participationDbQueryRepo);
            AddRepository<IProgamOwnerQueryRepo, ProgramOwner>(progamOwnerDbQueryRepo);
            AddRepository<IPublicSpaceQueryRepo, PublicSpace>(publicSpaceDbQueryRepo);
            AddRepository<IRegisteredUserQueryRepo, RegisteredUser>(registeredUserDbQueryRepo);
        }

        public IAddressDbQueryRepo AddressDbQueryRepo => GetRepository<IAddressDbQueryRepo, Address>() ?? new AddressDbQueryRepo<TDbContext>(dbContext);
        public IEditorDbQueryRepo EditorDbQueryRepo => GetRepository<IEditorDbQueryRepo, Editor>() ?? new EditorDbQueryRepo<TDbContext>(dbContext);
        public IOrganizationCategoryDbQueryRepo OrganizationCategoryDbQueryRepo => GetRepository<IOrganizationCategoryDbQueryRepo, OrganizationCategory>() ?? new OrganizationCategoryDbQueryRepo<TDbContext>(dbContext);
        public IOrganizationEditorDbQueryRepo OrganizationEditorDbQueryRepo => GetRepository<IOrganizationEditorDbQueryRepo, OrganizationEditor>() ?? new OrganizationEditorDbQueryRepo<TDbContext>(dbContext);
        public IOrganizationProgramDbQueryRepo OrganizationProgramDbQueryRepo => GetRepository<IOrganizationProgramDbQueryRepo, OrganizationProgram>() ?? new OrganizationProgramDbQueryRepo<TDbContext>(dbContext);
        public IOrganizationDbQueryRepo OrganizationDbQueryRepo => GetRepository<IOrganizationDbQueryRepo, Organization>() ?? new OrganizationDbQueryRepo<TDbContext>(dbContext);
        public IParticipationDbQueryRepo ParticipationDbQueryRepo => GetRepository<IParticipationDbQueryRepo, Participation>() ?? new ParticipationDbQueryRepo<TDbContext>(dbContext);
        public IProgamOwnerDbQueryRepo ProgramOwnerDbQueryRepo => GetRepository<IProgamOwnerDbQueryRepo, ProgramOwner>() ?? new ProgramOwnerDbQueryRepo<TDbContext>(dbContext);
        public IPublicSpaceDbQueryRepo PublicSpaceDbQueryRepo => GetRepository<IPublicSpaceDbQueryRepo, PublicSpace>() ?? new PublicSpaceDbQueryRepo<TDbContext>(dbContext);
        public IRegisteredUserDbQueryRepo RegisteredUserDbQueryRepo => GetRepository<IRegisteredUserDbQueryRepo, RegisteredUser>() ?? new RegisteredUserDbQueryRepo<TDbContext>(dbContext);
    }
}
