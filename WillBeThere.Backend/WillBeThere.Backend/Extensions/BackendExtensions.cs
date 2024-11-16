using Microsoft.AspNetCore.Identity;
using Shared.ApplicationLayer.Persistence;
using Shared.InfrastuctureLayer.Modules.Authentication.Models;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.ApplicationLayer.Repos.QueryRepo;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Repos;
using WillBeThere.InfrastuctureLayer.Context;
using WillBeThere.InfrastuctureLayer.Persistence.Context;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.WillBeThere;
using WillBeThere.InfrastuctureLayer.Persistence.Services;
using WillBeThere.InfrastuctureLayer.Persistence.Services.DataBase;

namespace WillBeThere.Backend.Extensions
{
    public static class BackendExtensions
    {
        public static void AddBackend(this IServiceCollection services) 
        {
            services.ConfigureCors();
            services.ConfigureBackendRepos();
            services.ConfigureBackendServices();
            services.AddAuthentication();
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
            if (true)
            {
                services.AddScoped<IOrganizationCategoryQueryRepo, OrganizationCategoryDbQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationProgramQueryRepo, OrganizationProgramDbQueryRepo<WillBeThereInMemoryContext>>();
            }
            services.AddScoped<IPublicOrgranizationProgramQueryRepo, PublicOrgranizationProgramDbQueryRepo>();
        }

        public static void ConfigureBackendServices(this IServiceCollection services)
        {
            services.AddScoped<IManyDataPersistenceService<OrganizationCategory>, ManyDataGenericDbPersistenceService<OrganizationCategory, OrganizationCategoryDto>>();
            services.AddScoped<IManyDataPersistenceService, ManyDataDbPersistenceService>();
        }

        public static void AddAuthentication(IServiceCollection services)
        {
            services.AddSingleton(TimeProvider.System);
            services.AddAuthorization();
            services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<WillBeThereMysqlIdentityContext>()
                //.AddApiEndpoints();
                .AddDefaultTokenProviders();
        }
    }
}
