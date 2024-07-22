using WillBeThere.HttpService.HttpService;
using WillBeThere.Shared.Assamblers;
using WillBeThere.Shared.Assamblers.ResultModels;

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
            services.AddScoped<AddressAssambler>();
            services.AddScoped<OrganizationAssambler>();
            services.AddScoped<OrganizationAdminAssambler>();
            services.AddScoped<OrganizationCategoryAssembler>();
            services.AddScoped<OrganizationProgramAssambler>();
            services.AddScoped<PartipationAssambler>();
            services.AddScoped<PublicSpaceAssambler>();
            services.AddScoped<RegisteredUserAssambler>();

            services.AddScoped<PublicOrganizationProgramAssambler>();

        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IPublicOrganizationHttpService, PublicOrganizationHttpService>();
        }
    }
}
