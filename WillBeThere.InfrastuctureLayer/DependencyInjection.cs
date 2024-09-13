using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.DomainLayer.Assemblers.ResultModels;
using WillBeThere.InfrastuctureLayer.Context;
using WillBeThere.InfrastuctureLayer.Handlers.OrganizationPrograms;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseRepos;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos;
using WillBeThere.InfrastuctureLayer.Implementations.Services;

namespace WillBeThere.InfrastuctureLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.ConfigureInMemoryContext();
            services.ConfigureMysqlContext();
            services.ConfigureAssamblers();
            services.ConfigureRepos();
            services.ConfigureServices();
            services.ConfigureCqrs();
            return services;
        }



        public static void ConfigureInMemoryContext(this IServiceCollection services)
        {
            string dbName = "WillBeThere" + Guid.NewGuid();
            services.AddDbContext<WillBeThereInMemoryContext>(
                options => options.UseInMemoryDatabase(databaseName: dbName)
            );
        }

        public static void ConfigureMysqlContext(this IServiceCollection services)
        {
            string connectionString = "server=localhost;userid=root;password=;database=willbethere;port=3306";
            services.AddDbContext<WillBeThereMysqlContext>(options => options.UseMySQL(connectionString));
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

        public static void ConfigureRepos(this IServiceCollection services)
        {
            if (true)
            {
                services.AddScoped<IPublicSpaceRepo, PublicSpaceRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IAddressQueryRepo, AddressRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationRepo, OrganiozationRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationAdminUserRepo, OrganizationAdminUserRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationCategoryRepo, OrganizationCategoryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationProgramQueryRepo, OrganizationProgramQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IParticipationRepo, ParticipationRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IRegisteredUserRepo, RegisteredUserRepo<WillBeThereInMemoryContext>>();
            }
            else
            {
                services.AddScoped<IPublicSpaceRepo, PublicSpaceRepo<WillBeThereMysqlContext>>();
                services.AddScoped<IAddressQueryRepo, AddressRepo<WillBeThereMysqlContext>>();
                services.AddScoped<IOrganizationRepo, OrganiozationRepo<WillBeThereMysqlContext>>();
                services.AddScoped<IOrganizationAdminUserRepo, OrganizationAdminUserRepo<WillBeThereMysqlContext>>();
                services.AddScoped<IOrganizationCategoryRepo, OrganizationCategoryRepo<WillBeThereMysqlContext>>();
                services.AddScoped<IOrganizationProgramQueryRepo, OrganizationProgramQueryRepo<WillBeThereMysqlContext>>();
                services.AddScoped<IParticipationRepo, ParticipationRepo<WillBeThereMysqlContext>>();
                services.AddScoped<IRegisteredUserRepo, RegisteredUserRepo<WillBeThereMysqlContext>>();
            }

            services.AddScoped<IWrapRepo, WrapCommandRepo>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IOrganizationProgramService, OrganizationProgramService>();
        }

        public static void ConfigureCqrs(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetPublicOrganizationProgramListHandler).Assembly));
        }
    }
}