using SharedApplicationLayer.Contracts.Persistence;
using WillBeThere.InfrastuctureLayer.Persistence.Services.Http;

namespace WillBeThere.Web.Extensions
{
    public static class WebExtensions
    {
        public static void AddWebServices(this IServiceCollection services)
        {
            services.ConfigureWebServices();
        }
        public static void ConfigureWebServices(this IServiceCollection services)
        {           
            services.AddScoped<IDataPersistenceService, DataPersistenceService>();            
        }
    }
}
