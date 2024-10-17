using SharedApplicationLayer.Contracts.Persistence;
using WillBeThere.InfrastuctureLayer.Persistence.Services.Http;


namespace WillBeThere.Web.Extensions
{
    public static class WebExtensions
    {
        public static void ConfigureWebServices(this IServiceCollection services)
        {
            services.AddScoped<IDataPersistenceService, DataPersistenceService>();
        }
    }
}
