using Microsoft.EntityFrameworkCore;
using WillBeThere.Application.Assemblers;
using WillBeThere.Backend.Repos;
using WillBeThere.Backend.Repos.WillBeThere;
using WillBeThere.Backend.Services;
using WillBeThere.Domain.Assemblers.ResultModels;
using WillBeThere.Infrastucture.Context;

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
            if (false)
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
    }
}
