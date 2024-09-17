using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SharedDomainLayer.Repos.Commands;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.UnitOfWork;
using WillBeThere.DomainLayer.Assemblers.ResultModels;
using WillBeThere.InfrastuctureLayer.Context;
using WillBeThere.InfrastuctureLayer.Handlers.OrganizationPrograms;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.UnifOfWorks;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos.Interfaces;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos.Repos;
using WillBeThere.InfrastuctureLayer.Implementations.Services;

namespace WillBeThere.InfrastuctureLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.ConfigureInMemoryContext();
            services.ConfigureMysqlContext();
            services.ConfigureAssamblers();
            services.ConfigureRepos();
            services.ConfigureServices();
            services.ConfigureCqrs();
            return services;
        }



        public static void ConfigureInMemoryContext(this IServiceCollection services)
        {
            string dbName = "WillBeThere" + Guid.NewGuid();
            services.AddDbContext<WillBeThereInMemoryContext>(
                options => options.UseInMemoryDatabase(databaseName: dbName)
            );
        }

        public static void ConfigureMysqlContext(this IServiceCollection services)
        {
            string connectionString = "server=localhost;userid=root;password=;database=willbethere;port=3306";
            services.AddDbContext<WillBeThereMysqlContext>(options => options.UseMySQL(connectionString));
        }

        public static void ConfigureAssamblers(this IServiceCollection services)
        {
            services.AddScoped<AddressAssembler>();
            services.AddScoped<EditorAssambler>();
            services.AddScoped<OrganizationAssembler>();
            services.AddScoped<OrganizationCategoryAssembler>();
            services.AddScoped<OrganizationProgramAssembler>();
            services.AddScoped<PartipationAssembler>();
            services.AddScoped<PublicSpaceAssembler>();
            services.AddScoped<ProgramOwnerAssembler>();
            services.AddScoped<PublicOrganizationProgramAssembler>();
            services.AddScoped<RegisteredUserAssembler>();
        }

        public static void ConfigureRepos(this IServiceCollection services)
        {
            if (true)
            {
                services.AddScoped<IAddressQueryRepo,AddressQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IEditorQueryRepo,EditorQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationCategoryQueryRepo,OrganizationCategoryQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationEditorQueryRepo,OrganizationEditorQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationProgramQueryRepo,OrganizationProgramQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationQueryRepo,OrganizationQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IParticipationQueryRepo,ParticipationQueryRepoo<WillBeThereInMemoryContext>>();
                services.AddScoped<IProgamOwnerQueryRepo,ProgramOwnerQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IPublicSpaceQueryRepo,PublicSpaceQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IRegisteredUserQueryRepo,RegisteredUserQueryRepo<WillBeThereInMemoryContext>>();


                services.AddScoped<IWrapRepos,WrapRepos<WillBeThereInMemoryContext>>();
                services.AddScoped<IWrapperUnitOfWork, WrapperUnitOfWork<WillBeThereMysqlContext>>();
                services.AddScoped<IUnitOfWork, UnitOfWork<WillBeThereInMemoryContext>>();
                services.AddScoped<IRepoStore,RepoStore<WillBeThereInMemoryContext>>();
            }
            else
            {
                /*services.AddScoped<IPublicSpaceRepo, PublicSpaceRepo<WillBeThereMysqlContext>>();
                services.AddScoped<IAddressQueryRepo, AddressRepo<WillBeThereMysqlContext>>();
                services.AddScoped<IOrganizationRepo, OrganiozationRepo<WillBeThereMysqlContext>>();
                services.AddScoped<IOrganizationAdminUserRepo, OrganizationAdminUserRepo<WillBeThereMysqlContext>>();
                services.AddScoped<IOrganizationCategoryRepo, OrganizationCategoryRepo<WillBeThereMysqlContext>>();*/
                services.AddScoped<IOrganizationProgramQueryRepo, OrganizationProgramQueryRepo<WillBeThereMysqlContext>>();
                services.AddScoped<IOrganizationProgramCommandRepo, OrganizationProgramCommandRepo<WillBeThereInMemoryContext>>();
                /*services.AddScoped<IParticipationRepo, ParticipationRepo<WillBeThereMysqlContext>>();
                services.AddScoped<IRegisteredUserRepo, RegisteredUserRepo<WillBeThereMysqlContext>>();*/
                //services.AddScoped<IWrapCommandRepo, RepoStore<WillBeThereMysqlContext>>();
                //services.AddScoped<IUnitOfWork, UnitOfWork<WillBeThereInMemoryContext>>();
            }
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IOrganizationProgramService, OrganizationProgramService>();
        }

        public static void ConfigureCqrs(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetPublicOrganizationProgramListHandler).Assembly));
        }
    }
}