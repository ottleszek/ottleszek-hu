using SharedApplicationLayer.Contracts.Persistence;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.DataServices;
using WillBeThere.InfrastuctureLayer.Persistence.Services.DataBase;
using WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base.DataService;

namespace WillBeThere.Backend.Extensions
{
    public static class BackendExtensions
    {
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

        public static void ConfigureBackendServices(this IServiceCollection services)
        {
            services.AddScoped<IDataPersistenceService, DbDataPersistenceService>();
            services.AddScoped<IBaseOrganizationCategoryDataService, BaseOrganizationCategoryDataService>();
        }

 
    }
}
