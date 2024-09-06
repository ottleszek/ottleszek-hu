using Microsoft.Extensions.DependencyInjection;
using WillBeThere.Application.Assemblers;
using WillBeThere.Application.Services.DataService;
using WillBeThere.Application.Services.HttpService;
using WillBeThere.Application.Services.MapperService;
using WillBeThere.Domain.Assemblers.ResultModels;

namespace WillBeThere.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.ConfigureHttpCliens();
            services.ConfigureAssamblers();
            services.ConfigureServices();
            return services;
        }

        public static void ConfigureHttpCliens(this IServiceCollection services)
        {
            services.AddHttpClient("WillBeThere", options =>
            {
                options.BaseAddress = new Uri("https://localhost:7080/");
            });
        }
        public static void ConfigureAssamblers(this IServiceCollection services)
        {
            services.AddScoped<AddressAssembler>();
            services.AddScoped<OrganizationAssembler>();
            services.AddScoped<OrganizationAdminAssembler>();
            services.AddScoped<OrganizationCategoryAssembler>();
            services.AddScoped<OrganizationProgramAssembler>();
            services.AddScoped<PartipationAssembler>();
            services.AddScoped<PublicSpaceAssembler>();
            services.AddScoped<RegisteredUserAssembler>();

            services.AddScoped<PublicOrganizationProgramAssembler>();

        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            // HttpService
            services.AddScoped<IOrganizationProgramHttpService, OrganizationProgramHttpService>();
            services.AddScoped<IOrganizationCategoryHttpService, OrganizationCategoryHttpService>();

            // MapperService
            services.AddScoped<IOrganizationProgramMapperService, OrganizationProgramMapperService>();
            services.AddScoped<IOrganizationCategoryMapperService, OrganizationCategoryMapperService>();

            // DataService
            services.AddScoped<IOrganizationProgramDataService, OrganizationProgramDataService>();
            services.AddScoped<IOrganizationCategoryDataService, OrganizationCategoryDataService>();
        }
    }
}
