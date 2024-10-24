using SharedApplicationLayer.Contracts.Persistence;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;
using WillBeThere.ApplicationLayer.Repos.QueryRepo;
using WillBeThere.DomainLayer.Repos;
using WillBeThere.InfrastuctureLayer.Context;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.Repos.DataBase;
using WillBeThere.InfrastuctureLayer.Persistence.Services.DataBase;

namespace WillBeThere.Backend.Extensions
{
    public static class BackendExtensions
    {
        public static void AddBackendServices(this IServiceCollection services) 
        {
            services.ConfigureBackendRepos();
            services.ConfigureBackendServices();

        }
        public static void ConfigureCors(this IServiceCollection services)
        {

            services.AddCors(option =>
                 option.AddPolicy(name: "KretaCors",
                     policy =>
                     {
                         policy.WithOrigins("https://localhost:7080/")
                         .AllowAnyHeader()
                         .AllowAnyMethod();
                     }
                 )
            );
        }

        public static void ConfigureBackendRepos(this IServiceCollection services)
        {
            services.AddScoped<IOrganizationCategoryQueryRepo, DbOrganizationCategoryQueryRepo<WillBeThereInMemoryContext>>();
;
            services.AddScoped<IOrganizationProgramRepo, DbOrganizationProgramRepo>();
        }

        public static void ConfigureBackendServices(this IServiceCollection services)
        {
            services.AddScoped<IDataPersistenceService, DbDataPersistenceService>();
            //services.AddScoped<IBaseOrganizationCategoryDataService, BaseOrganizationCategoryDataService>();
        }

 
    }
}
