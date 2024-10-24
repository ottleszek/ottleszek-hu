using Microsoft.EntityFrameworkCore;
using WillBeThere.ApplicationLayer.Repos.QueryRepo;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos.Repos;
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

        //public override IBaseRepo Repository => base.Repository;

        public IAddressQueryRepo AddressQueryRepo => GetRepository<IAddressQueryRepo, Address>() ?? new AddressQueryRepo<TDbContext>(dbContext);
        public IEditorQueryRepo EditorQueryRepo => GetRepository<IEditorQueryRepo, Editor>() ?? new EditorQueryRepo<TDbContext>(dbContext);
        public IOrganizationCategoryQueryRepo OrganizationCategoryQueryRepo => GetRepository<IOrganizationCategoryQueryRepo, OrganizationCategory>() ?? new OrganizationCategoryQueryRepo<TDbContext>(dbContext);
        public IOrganizationEditorQueryRepo OrganizationEditorQueryRepo => GetRepository<IOrganizationEditorQueryRepo, OrganizationEditor>() ?? new OrganizationEditorQueryRepo<TDbContext>(dbContext);
        public IOrganizationProgramQueryRepo OrganizationProgramQueryRepo => GetRepository<IOrganizationProgramQueryRepo, OrganizationProgram>() ?? new OrganizationProgramQueryRepo<TDbContext>(dbContext);
        public IOrganizationQueryRepo OrganizationQueryRepo => GetRepository<IOrganizationQueryRepo, Organization>() ?? new OrganizationQueryRepo<TDbContext>(dbContext);
        public IParticipationQueryRepo ParticipationQueryRepo => GetRepository<IParticipationQueryRepo, Participation>() ?? new ParticipationQueryRepoo<TDbContext>(dbContext);
        public IProgamOwnerQueryRepo ProgramOwnerQueryRepo => GetRepository<IProgamOwnerQueryRepo, ProgramOwner>() ?? new ProgramOwnerQueryRepo<TDbContext>(dbContext);
        public IPublicSpaceQueryRepo PublicSpaceQueryRepo => GetRepository<IPublicSpaceQueryRepo, PublicSpace>() ?? new PublicSpaceQueryRepo<TDbContext>(dbContext);
        public IRegisteredUserQueryRepo RegisteredUserQueryRepo => GetRepository<IRegisteredUserQueryRepo, RegisteredUser>() ?? new RegisteredUserQueryRepo<TDbContext>(dbContext);
    }
}
