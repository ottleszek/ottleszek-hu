using Microsoft.EntityFrameworkCore;
using WillBeThere.ApplicationLayer.Contracts.UnitOfWork;
using WillBeThere.ApplicationLayer.Repos.QueryRepo;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.UnifOfWorks;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos
{
    public class WillBeThereWrapQueryUnitOfWork<TDbContext> : WrapperQueryUnitOfWork<TDbContext>, IWillBeThereWrapQueryUnitOfWork where TDbContext : DbContext
    {
        private TDbContext dbContext;
        public WillBeThereWrapQueryUnitOfWork
            (
                TDbContext dbContext,
                IAddressQueryRepo addressQueryRepo,
                IEditorQueryRepo editorQueryRepo,
                IOrganizationCategoryQueryRepo organizationCategoryQueryRepo,
                IOrganizationEditorQueryRepo organizationEditorQueryRepo,
                IOrganizationProgramQueryRepo organizationProgramQueryRepo,
                IOrganizationQueryRepo organizationQueryRepo,
                IParticipationQueryRepo participationQueryRepo,
                IProgamOwnerQueryRepo progamOwnerQueryRepo,
                IPublicSpaceQueryRepo publicSpaceQueryRepo,
                IRegisteredUserQueryRepo registeredUserQueryRepo
            )
            : base(dbContext, organizationQueryRepo)
        {
            this.dbContext = dbContext;
            AddRepository<IAddressQueryRepo, Address>(addressQueryRepo);
            AddRepository<IEditorQueryRepo, Editor>(editorQueryRepo);
            AddRepository<IOrganizationCategoryQueryRepo, OrganizationCategory>(organizationCategoryQueryRepo);
            AddRepository<IOrganizationEditorQueryRepo, OrganizationEditor>(organizationEditorQueryRepo);
            AddRepository<IOrganizationProgramQueryRepo, OrganizationProgram>(organizationProgramQueryRepo);
            AddRepository<IOrganizationQueryRepo, OrganizationEditor>(organizationQueryRepo);
            AddRepository<IParticipationQueryRepo, Participation>(participationQueryRepo);
            AddRepository<IProgamOwnerQueryRepo, ProgramOwner>(progamOwnerQueryRepo);
            AddRepository<IPublicSpaceQueryRepo, PublicSpace>(publicSpaceQueryRepo);
            AddRepository<IRegisteredUserQueryRepo, RegisteredUser>(registeredUserQueryRepo);
        }

        public IAddressQueryRepo AddressQueryRepo => GetRepository<IAddressQueryRepo, Address>() ?? new AddressDbQueryRepo<TDbContext>(dbContext);
        public IEditorQueryRepo EditorQueryRepo => GetRepository<IEditorQueryRepo, Editor>() ?? new EditorDbQueryRepo<TDbContext>(dbContext);
        public IOrganizationCategoryQueryRepo OrganizationCategoryQueryRepo => GetRepository<IOrganizationCategoryQueryRepo, OrganizationCategory>() ?? new OrganizationCategoryDbQueryRepo<TDbContext>(dbContext);
        public IOrganizationEditorQueryRepo OrganizationEditorQueryRepo => GetRepository<IOrganizationEditorQueryRepo, OrganizationEditor>() ?? new OrganizationEditorDbQueryRepo<TDbContext>(dbContext);
        public IOrganizationProgramQueryRepo OrganizationProgramQueryRepo => GetRepository<IOrganizationProgramQueryRepo, OrganizationProgram>() ?? new OrganizationProgramDbQueryRepo<TDbContext>(dbContext);
        public IOrganizationQueryRepo OrganizationQueryRepo => GetRepository<IOrganizationQueryRepo, Organization>() ?? new OrganizationDbQueryRepo<TDbContext>(dbContext);
        public IParticipationQueryRepo ParticipationQueryRepo => GetRepository<IParticipationQueryRepo, Participation>() ?? new ParticipationDbQueryRepo<TDbContext>(dbContext);
        public IProgamOwnerQueryRepo ProgramOwnerQueryRepo => GetRepository<IProgamOwnerQueryRepo, ProgramOwner>() ?? new ProgramOwnerDbQueryRepo<TDbContext>(dbContext);
        public IPublicSpaceQueryRepo PublicSpaceQueryRepo => GetRepository<IPublicSpaceQueryRepo, PublicSpace>() ?? new PublicSpaceDbQueryRepo<TDbContext>(dbContext);
        public IRegisteredUserQueryRepo RegisteredUserQueryRepo => GetRepository<IRegisteredUserQueryRepo, RegisteredUser>() ?? new RegisteredDbUserQueryRepo<TDbContext>(dbContext);
    }
}
