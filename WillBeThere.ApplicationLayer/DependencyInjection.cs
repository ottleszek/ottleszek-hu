using Microsoft.Extensions.DependencyInjection;
using WillBeThere.ApplicationLayer.Commands.OrganizationCategories;
using WillBeThere.ApplicationLayer.Queries.OrganizationCategories;
using WillBeThere.ApplicationLayer.Queries.OrganizationPrograms;
using WillBeThere.ApplicationLayer.Transformers.Assemblers;
using WillBeThere.ApplicationLayer.Transformers.Assemblers.ResultModels;
using WillBeThere.ApplicationLayer.ViewModels.OrganizationCategories;


namespace WillBeThere.ApplicationLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.ConfigureHttpClient();
            services.ConfigureAssamblers();
            services.ConfigureRepos();
            services.ConfigureViewModels();
            services.ConfigureCqrs();
            return services;
        }

        public static void ConfigureHttpClient(this IServiceCollection services)
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

        public static void ConfigureRepos(this IServiceCollection services)
        {
            //services.AddScoped<IOrganizationCategoryRepository, OrganizationCategoryRepository>();            
        }

        public static void ConfigureViewModels(this IServiceCollection services)
        {
            services.AddScoped<IOrganizationCategoryListViewModel, OrganizationCategoryListViewModel>();
        }

        public static void ConfigureCqrs(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(SaveOrganizationCategoriesCommandHandler).Assembly));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetOrganizationCategoriesListQueryHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetPublicOrganizationProgramListQueryHandler).Assembly));
        }
    }
}
