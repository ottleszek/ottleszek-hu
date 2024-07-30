using WillBeThere.HttpService.DataService;
using WillBeThere.HttpService.HttpService;
using WillBeThere.HttpService.MapperService;
using WillBeThere.Shared.Assemblers;
using WillBeThere.Shared.Assemblers.ResultModels;
using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Dtos.ResultModels;
using WillBeThere.Shared.Models;
using WillBeThere.Shared.Models.ResultModels;

namespace WillBeThere.Web.Extensions
{
    public static class WebExtensions
    {
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
            services.AddScoped<OrganizationAssembler >();
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
            services.AddScoped<IOrganizationProgramMapperService, OrganizationProgramMapperService> ();
            services.AddScoped<IOrganizationCategoryMapperService, OrganizationCategoryMapperService>();

            // DataService
            services.AddScoped<IOrganizationProgramDataService,OrganizationProgramDataService >();
            services.AddScoped<IOrganizationCategoryDataService, OrganizationCategoryDataService>();
            

        }
    }
}
