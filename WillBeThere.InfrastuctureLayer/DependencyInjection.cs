using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.InfrastuctureLayer.Context;
using WillBeThere.InfrastuctureLayer.Persistence.Services.Http;
using WillBeThere.ApplicationLayer.Transformers.Assemblers;
using WillBeThere.ApplicationLayer.Transformers.Assemblers.ResultModels;
using WillBeThere.ApplicationLayer.Transformers.Converters;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;
using WillBeThere.ApplicationLayer.Repos.QueryRepo;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.UnifOfWorks;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.Http.HttpRepo.Query;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.Http.MapperRepo.Query;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.Http.ModelRepo.Query;
using Shared.ApplicationLayer.Transformers;
using Shared.ApplicationLayer.Repos;
using Shared.InfrastuctureLayer.Repos.DataBase;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.HttpRepo;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.MapperRepo;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.MappreRepo;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.ModelRepo;
using Shared.ApplicationLayer.Persistence;
using Shared.ApplicationLayer.Repos.UnitOfWork;
using WillBeThere.ApplicationLayer.Contracts.UnitOfWork;
using Shared.InfrastuctureLayer.Repos.DataBase.Commands;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.ApplicationLayer.Contracts.Dtos.ResultModels;
using WillBeThere.DomainLayer.Entites.ResultModels;
using WillBeThere.InfrastuctureLayer.Persistence.Services;

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

        public static void ConfigureHttpClient(this IServiceCollection services)
        {
            services.AddHttpClient("WillBeThere", options =>
            {
                options.BaseAddress = new Uri("https://localhost:7080/");
            });
        }

        public static void ConfigureAssamblers(this IServiceCollection services)
        {
            services.AddScoped<IAssembler<Address, AddressDto>,AddressAssembler>();
            services.AddScoped<IAssembler<Editor, EditorDto>, EditorAssambler>();
            services.AddScoped<IAssembler<Organization, OrganizationDto>, OrganizationAssembler>();
            services.AddScoped<IAssembler<OrganizationCategory, OrganizationCategoryDto>, OrganizationCategoryAssembler >();
            services.AddScoped<IAssembler<OrganizationProgram, OrganizationProgramDto>, OrganizationProgramAssembler>();
            services.AddScoped<IAssembler<Participation, ParticipationDto>, PartipationAssembler>();
            services.AddScoped<IAssembler<PublicSpace, PublicSpaceDto>, PublicSpaceAssembler>();
            services.AddScoped<IAssembler<ProgramOwner, ProgramOwnerDto>, ProgramOwnerAssembler>();
            services.AddScoped<IAssembler<PublicOrganizationProgram, PublicOrganizationProgramDto>, PublicOrganizationProgramAssembler>();
            services.AddScoped<IAssembler<RegisteredUser, RegisteredUserDto>,RegisteredUserAssembler>();
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
                services.AddScoped<IBaseDbRepo, BaseDbRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IBaseCommandDbRepo, BaseCommandDbRepo<WillBeThereInMemoryContext>>();

                services.AddScoped<IAddressQueryRepo,AddressDbQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IEditorQueryRepo,EditorDbQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationCategoryQueryRepo,OrganizationCategoryDbQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationEditorQueryRepo,OrganizationEditorDbQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationProgramQueryRepo,OrganizationProgramDbQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationQueryRepo,OrganizationDbQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IParticipationQueryRepo,ParticipationDbQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IProgamOwnerQueryRepo,ProgramOwnerDbQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IPublicSpaceQueryRepo,PublicSpaceDbQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IRegisteredUserQueryRepo,RegisteredDbUserQueryRepo<WillBeThereInMemoryContext>>();

                services.AddScoped<IBaseAddressCommandRepo, AddressDbCommandRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IBaseEditorCommandRepo, EditorDbCommandRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IBaseOrganizationCategoryCommandRepo, OrganizationCategoryDbCommandRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IBaseOrganizationEditorCommandRepo, OrganizationEditorDbCommandRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IBaseOrganizationProgramCommandRepo, OrganizationProgramDbCommandRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IBaseOrganizationCommandRepo, OrganizationDbCommandRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IBaseParticipationCommandRepo, ParticipationCommandDbRepoo<WillBeThereInMemoryContext>>();
                services.AddScoped<IBaseProgamOwnerCommandRepo, ProgramOwnerDbCommandRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IBasePublicSpaceCommandRepo, PublicSpaceDbCommandRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IBaseRegisteredUserCommandRepo, RegisteredUserDbCommandRepo<WillBeThereInMemoryContext>>();

                services.AddScoped<IUnitOfWork, UnitOfWork<WillBeThereInMemoryContext>>();
                //services.AddScoped<IRepoStore, WrapperUnitOfWork<WillBeThereInMemoryContext>>();
                //services.AddScoped<IWrapperUnitOfWork, WrapperUnitOfWork<WillBeThereInMemoryContext>>();

                services.AddScoped<IWillBeThereWrapQueryUnitOfWork,WillBeThereWrapQueryUnitOfWork<WillBeThereInMemoryContext>>();

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
            services.AddScoped<IOrganizationProgramQueryHttpRepo, OrganizationProgramQueryHttpRepo>();
            services.AddScoped<IOrganizationCategoryQueryHttpRepo, OrganizationCategoryQueryHttpRepo>();

            // MapperService
            services.AddScoped<IOrganizationProgramQueryMapperRepo, OrganizationProgramQueryMapperRepo>();
            services.AddScoped<IOrganizationCategoryQueryMapperRepo, OrganizationCategoryQueryMapperRepo>();

            // ModelService
            services.AddScoped<IOrganizationProgramQueryModelRepo, OrganizationProgramQueryModelRepo>();
            services.AddScoped<IOrganizationCategoryQueryModelRepo, OrganizationCategoryQueryModelRepo>();
        }

        public static void ConfigurePersistence(this IServiceCollection services)
        {
            //services.AddScoped<IManyDataPersistenceService, ManyDataHttpPersistenceService>();
            services.AddScoped<IManyDataPersistenceService<OrganizationCategory>, ManyGenericDataPersistenceService<OrganizationCategory, OrganizationCategoryDto>>();
        }
    }
}