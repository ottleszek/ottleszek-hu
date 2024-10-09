using Microsoft.Extensions.DependencyInjection;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Commands.OrganizationCategories;
using WillBeThere.ApplicationLayer.Contracts.Repositories;
using WillBeThere.ApplicationLayer.Contracts.Services.DataService;
using WillBeThere.ApplicationLayer.Contracts.Services.HttpService;
using WillBeThere.ApplicationLayer.Contracts.Services.MapperService;
using WillBeThere.ApplicationLayer.Queries.OrganizationCategories;
using WillBeThere.ApplicationLayer.Repository.OrgaizationCategories;
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
            services.ConfigureRepositories();
            services.ConfigureServices();
            services.ConfigureViewModels();
            services.ConfigureCqrs();
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

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrganizationCategoryRepository, OrganizationCategoryRepository>();            
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

        public static void ConfigureCqrs(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(SaveOrganizationCategoriesCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetOrganizationsCategoriesQuery).Assembly));
        }
    }
}
