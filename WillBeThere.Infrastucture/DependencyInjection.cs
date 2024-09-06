using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WillBeThere.Application.Assemblers;
using WillBeThere.Domain.Assemblers.ResultModels;
using WillBeThere.Infrastucture.Context;
using WillBeThere.Infrastucture.Handlers.OrganizationPrograms;
using WillBeThere.Infrastucture.Implementations.Repos.BaseRepos;
using WillBeThere.Infrastucture.Implementations.Repos.WillBeThere;
using WillBeThere.Infrastucture.Implementations.Services;

namespace WillBeThere.Infrastucture
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
                services.AddScoped<IAddressRepo, AddressRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationRepo, OrganiozationRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationAdminUserRepo, OrganizationAdminUserRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationCategoryRepo, OrganizationCategoryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationProgramRepo, OrganizationProgramRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IParticipationRepo, ParticipationRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IRegisteredUserRepo, RegisteredUserRepo<WillBeThereInMemoryContext>>();
            }
            else
            {
                services.AddScoped<IPublicSpaceRepo, PublicSpaceRepo<WillBeThereMysqlContext>>();
                services.AddScoped<IAddressRepo, AddressRepo<WillBeThereMysqlContext>>();
                services.AddScoped<IOrganizationRepo, OrganiozationRepo<WillBeThereMysqlContext>>();
                services.AddScoped<IOrganizationAdminUserRepo, OrganizationAdminUserRepo<WillBeThereMysqlContext>>();
                services.AddScoped<IOrganizationCategoryRepo, OrganizationCategoryRepo<WillBeThereMysqlContext>>();
                services.AddScoped<IOrganizationProgramRepo, OrganizationProgramRepo<WillBeThereMysqlContext>>();
                services.AddScoped<IParticipationRepo, ParticipationRepo<WillBeThereMysqlContext>>();
                services.AddScoped<IRegisteredUserRepo, RegisteredUserRepo<WillBeThereMysqlContext>>();
            }

            services.AddScoped<IWrapRepo, WrapRepo>();
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