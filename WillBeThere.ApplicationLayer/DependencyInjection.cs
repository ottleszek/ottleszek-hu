using Microsoft.Extensions.DependencyInjection;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.Services.DataService;
using WillBeThere.ApplicationLayer.Contracts.Services.HttpService;
using WillBeThere.ApplicationLayer.Contracts.Services.MapperService;
using WillBeThere.ApplicationLayer.ViewModels.OrganizationCategories;
using WillBeThere.DomainLayer.Assemblers.ResultModels;

namespace WillBeThere.ApplicationLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.ConfigureHttpCliens();
            services.ConfigureAssamblers();
            services.ConfigureServices();
            services.ConfigureViewModels();
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
            services.AddScoped<ProgramOwnerAssembler>();
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

        public static void ConfigureViewModels(this IServiceCollection services)
        {
            services.AddScoped<IOrganizationCategoryListViewModel, OrganizationCategoryListViewModel>();
        }
    }
}
