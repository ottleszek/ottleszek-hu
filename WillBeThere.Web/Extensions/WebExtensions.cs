using SharedApplicationLayer.Contracts.Persistence;
using SharedApplicationLayer.Repos;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.DataServices;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.HttpServices;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.MapperServices;
using WillBeThere.ApplicationLayer.Contracts.UnitOfWork;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;
using WillBeThere.ApplicationLayer.Repos.QueryRepo;
using WillBeThere.ApplicationLayer.Transformers.Converters;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Services.Base;
using WillBeThere.InfrastuctureLayer.Context;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.Base;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.UnifOfWorks;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos.Repos;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos;
using WillBeThere.InfrastuctureLayer.Implementations.Services;
using WillBeThere.InfrastuctureLayer.Persistence.Services.Http;
using WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base.DataService;
using WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base.HttpService;
using WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base.MapperService;
using Microsoft.EntityFrameworkCore;


namespace WillBeThere.Web.Extensions
{
    public static class WebExtensions
    {
        public static void ConfigureWebServices(this IServiceCollection services)
        {
            services.AddScoped<IDataPersistenceService, DataPersistenceService>();
            services.AddScoped<IBaseOrganizationCategoryDataService, BaseOrganizationCategoryDataService>();
            services.AddScoped<IBaseOrganizationCategoryMapperService, BaseOrganizationCategoryMapperService>();

            // HttpService
            services.AddScoped<IBaseOrganizationProgramHttpService, BaseOrganizationProgramHttpService>();
            services.AddScoped<IBaseOrganizationCategoryHttpService, BaseOrganizationCategoryHttpService>();

            // MapperService
            services.AddScoped<IBaseOrganizationProgramMapperService, BaseOrganizationProgramMapperService>();
            services.AddScoped<IBaseOrganizationCategoryMapperService, BaseOrganizationCategoryMapperService>();

            // DataService
            services.AddScoped<IBaseOrganizationProgramDataService, BaseOrganizationProgramDataService>();
            services.AddScoped<IBaseOrganizationCategoryDataService, BaseOrganizationCategoryDataService>();

            services.AddScoped<IOrganizationProgramService, OrganizationProgramService>();
            services.AddScoped<IBaseOrganizationCategoryService, BaseOrganizationCategoryServices>();
            services.AddScoped<IBaseOrganizationCategoryDataService, BaseOrganizationCategoryDataService>();


            services.AddScoped<IDataPersistenceService<OrganizationCategory>, GenericDataPersistenceService<OrganizationCategory, OrganizationCategoryDto, OrganizationCategoryDomainDtoConverter>>();
            services.AddScoped<IHttpPersistenceService, HttpPersistenceService>();

            services.AddScoped<IAddressQueryRepo, AddressQueryRepo<WillBeThereInMemoryContext>>();
            services.AddScoped<IEditorQueryRepo, EditorQueryRepo<WillBeThereInMemoryContext>>();
            services.AddScoped<IOrganizationCategoryQueryRepo, OrganizationCategoryQueryRepo<WillBeThereInMemoryContext>>();
            services.AddScoped<IOrganizationEditorQueryRepo, OrganizationEditorQueryRepo<WillBeThereInMemoryContext>>();
            services.AddScoped<IOrganizationProgramQueryRepo, OrganizationProgramQueryRepo<WillBeThereInMemoryContext>>();
            services.AddScoped<IOrganizationQueryRepo, OrganizationQueryRepo<WillBeThereInMemoryContext>>();
            services.AddScoped<IParticipationQueryRepo, ParticipationQueryRepoo<WillBeThereInMemoryContext>>();
            services.AddScoped<IProgamOwnerQueryRepo, ProgramOwnerQueryRepo<WillBeThereInMemoryContext>>();
            services.AddScoped<IPublicSpaceQueryRepo, PublicSpaceQueryRepo<WillBeThereInMemoryContext>>();
            services.AddScoped<IRegisteredUserQueryRepo, RegisteredUserQueryRepo<WillBeThereInMemoryContext>>();

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

            services.AddScoped<IWillBeThereWrapQueryUnitOfWork, WillBeThereWrapQueryUnitOfWork<WillBeThereInMemoryContext>>();
            services.AddScoped<IWrapperUnitOfWork, WrapperUnitOfWork<WillBeThereInMemoryContext>>();
            services.AddScoped<IUnitOfWork, UnitOfWork<WillBeThereInMemoryContext>>();
            services.AddScoped<IRepoStore, WrapperUnitOfWork<WillBeThereInMemoryContext>>();

            services.AddScoped<IBaseRepo, BaseRepo<WillBeThereInMemoryContext>>();

            string dbName = "WillBeThere" + Guid.NewGuid();
            services.AddDbContext<WillBeThereInMemoryContext>(
                options => options.UseInMemoryDatabase(databaseName: dbName)
            );

        }
    }
}
