using Shared.ApplicationLayer.Persistence;
using WillBeThere.DomainLayer.Repos;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.Http;
using WillBeThere.InfrastuctureLayer.Persistence.Services.Http;

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
            services.AddScoped<IOrganizationProgramRepo, OrganizationProgramHttpRepo>();
        }
        public static void ConfigureWebServices(this IServiceCollection services)
        {           
            services.AddScoped<IManyDataPersistenceService, ManyDataHttpPersistenceService>();            
        }
    }
}
