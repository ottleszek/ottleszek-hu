using Shared.ApplicationLayer.Persistence;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.ApplicationLayer.Repos.QueryRepo;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Repos;
using WillBeThere.InfrastuctureLayer.Adapters.Repos;
using WillBeThere.InfrastuctureLayer.Adapters.Services;

namespace WillBeThere.Web.Extensions
{
    public static class WebExtensions
    {
        public static void AddWebServices(this IServiceCollection services)
        {
            services.ConfigureWebRepos();
            services.ConfigureWebServices();
        }
        public static void ConfigureWebRepos(this IServiceCollection services)
        {
            services.AddScoped<IOrganizationCategoryQueryRepo, OrganizationCategoryQueryDataRepo>();
            services.AddScoped<IPublicOrgranizationProgramQueryRepo, PublicOrgranizationProgramHttpQueryRepo>();
        }
        public static void ConfigureWebServices(this IServiceCollection services)
        {           
            services.AddScoped<IManyDataPersistenceService<OrganizationCategory>, ManyDataGenericHttpPersistenceService<OrganizationCategory,OrganizationCategoryDto>>();
            services.AddScoped<IManyDataPersistenceService, ManyDataHttpPersistenceService>();
        }
    }
}
