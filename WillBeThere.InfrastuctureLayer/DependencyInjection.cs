using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SharedApplicationLayer.Transformers;
using SharedApplicationLayer.Contracts.Persistence;
using SharedApplicationLayer.Repos;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.ApplicationLayer.Contracts.UnitOfWork;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.InfrastuctureLayer.Context;
using WillBeThere.InfrastuctureLayer.Persistence.Services.Http;
using WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base.DataService;
using WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base.HttpService;
using WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base.MapperService;
using WillBeThere.ApplicationLayer.Transformers.Assemblers;
using WillBeThere.ApplicationLayer.Transformers.Assemblers.ResultModels;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.HttpServices;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.DataServices;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.MapperServices;
using WillBeThere.ApplicationLayer.Transformers.Converters;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;
using WillBeThere.ApplicationLayer.Repos.QueryRepo;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.Repos.DataBase;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.UnifOfWorks;
using SharedApplicationLayer.Repos.Commands;
using WillBeThere.InfrastuctureLayer.Persistence.DataBase;
using WillBeThere.InfrastuctureLayer.Persistence.DataBase.Commands;

namespace WillBeThere.InfrastuctureLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.ConfigureHttpClient();
            services.ConfigureInMemoryContext();
            services.ConfigureMysqlContext();
            services.ConfigureAssamblers();
            services.ConfigureConverters();
            services.ConfigureRepos();
            services.ConfigureServices();
            services.ConfigurePersistence();
            return services;
        }

        public static void ConfigureHttpClient(this IServiceCollection services)
        {
            services.AddHttpClient("WillBeThere", options =>
            {
                options.BaseAddress = new Uri("https://localhost:7080/");
            });
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

        public static void ConfigureConverters(this IServiceCollection services)
        {
            services.AddScoped<IDomainDtoConterter<OrganizationCategory, OrganizationCategoryDto>, DomainDtoConverter<OrganizationCategory, OrganizationCategoryDto, OrganizationCategoryAssembler>>();
            services.AddScoped<OrganizationCategoryDomainDtoConverter>();
        }

        public static void ConfigureRepos(this IServiceCollection services)
        {
            if (true)
            {
                services.AddScoped<IAddressQueryRepo,DbAddressQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IEditorQueryRepo,DbEditorQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationCategoryQueryRepo,DbOrganizationCategoryQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationEditorQueryRepo,DbOrganizationEditorQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationProgramQueryRepo,DbOrganizationProgramQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationQueryRepo,DbOrganizationQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IParticipationQueryRepo,ParticipationQueryRepoo<WillBeThereInMemoryContext>>();
                services.AddScoped<IProgamOwnerQueryRepo,DbProgramOwnerQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IPublicSpaceQueryRepo,DbPublicSpaceQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IRegisteredUserQueryRepo,DbRegisteredUserQueryRepo<WillBeThereInMemoryContext>>();

                services.AddScoped<IBaseAddressCommandRepo, AddressCommandRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IBaseEditorCommandRepo, EditorCommandRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IBaseOrganizationCategoryCommandRepo, OrganizationCategoryCommandRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IBaseOrganizationEditorCommandRepo, OrganizationEditorCommandRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IBaseOrganizationProgramCommandRepo, OrganizationProgramCommandRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IBaseOrganizationCommandRepo, OrganizationCommandRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IBaseParticipationCommandRepo, ParticipationCommandRepoo<WillBeThereInMemoryContext>>();
                services.AddScoped<IBaseProgamOwnerCommandRepo, ProgramOwnerCommandRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IBasePublicSpaceCommandRepo, PublicSpaceCommandRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IBaseRegisteredUserCommandRepo, RegisteredUserCommandRepo<WillBeThereInMemoryContext>>();

                services.AddScoped<IWillBeThereWrapQueryUnitOfWork,WillBeThereWrapQueryUnitOfWork<WillBeThereInMemoryContext>>();
                services.AddScoped<IWrapperUnitOfWork, WrapperUnitOfWork<WillBeThereInMemoryContext>>();
                services.AddScoped<IUnitOfWork, UnitOfWork<WillBeThereInMemoryContext>>();
                services.AddScoped<IRepoStore,WrapperUnitOfWork<WillBeThereInMemoryContext>>();

                services.AddScoped<IBaseDbRepo, BaseDbRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<ICommandGenericMethodRepo,BaseCommandRepo<WillBeThereInMemoryContext>>();

            }
            else
            {
                /*services.AddScoped<IPublicSpaceRepo, PublicSpaceRepo<WillBeThereMysqlContext>>();
                services.AddScoped<IAddressQueryRepo, AddressRepo<WillBeThereMysqlContext>>();
                services.AddScoped<IOrganizationRepo, OrganiozationRepo<WillBeThereMysqlContext>>();
                services.AddScoped<IOrganizationAdminUserRepo, OrganizationAdminUserRepo<WillBeThereMysqlContext>>();
                services.AddScoped<IOrganizationCategoryRepo, OrganizationCategoryRepo<WillBeThereMysqlContext>>();*/
                //services.AddScoped<IOrganizationProgramQueryRepo, OrganizationProgramQueryRepo<WillBeThereMysqlContext>>();
                //services.AddScoped<IOrganizationProgramCommandRepo, OrganizationProgramCommandRepo<WillBeThereInMemoryContext>>();
                /*services.AddScoped<IParticipationRepo, ParticipationRepo<WillBeThereMysqlContext>>();
                services.AddScoped<IRegisteredUserRepo, RegisteredUserRepo<WillBeThereMysqlContext>>();*/
                //services.AddScoped<IWrapCommandRepo, RepoStore<WillBeThereMysqlContext>>();
                //services.AddScoped<IUnitOfWork, UnitOfWork<WillBeThereInMemoryContext>>();
            }
        }


        public static void ConfigureServices(this IServiceCollection services)
        {
            // HttpService
            services.AddScoped<IBaseOrganizationProgramHttpService, BaseOrganizationProgramHttpService>();
            services.AddScoped<IBaseOrganizationCategoryHttpService, BaseOrganizationCategoryHttpService>();

            // MapperService
            services.AddScoped<IBaseOrganizationProgramMapperService, BaseOrganizationProgramMapperService>();
            services.AddScoped<IBaseOrganizationCategoryMapperService, BaseOrganizationCategoryMapperService>();

            // DataService
            services.AddScoped<IBaseOrganizationProgramDataService, BaseOrganizationProgramDataService>();
            services.AddScoped<IBaseOrganizationCategoryDataService, BaseOrganizationCategoryDataService>();
                   
            services.AddScoped<IBaseOrganizationCategoryDataService, BaseOrganizationCategoryDataService>();


        }

        public static void ConfigurePersistence(this IServiceCollection services)
        {
            services.AddScoped<IHttpDataPersistenceService, HttpDataPersistenceService>();
            services.AddScoped<IDataPersistenceService<OrganizationCategory>, GenericDataPersistenceService<OrganizationCategory, OrganizationCategoryDto, OrganizationCategoryDomainDtoConverter>>();

        }
    }
}