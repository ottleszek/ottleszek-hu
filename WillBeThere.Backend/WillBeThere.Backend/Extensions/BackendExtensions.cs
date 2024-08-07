﻿using Microsoft.EntityFrameworkCore;
using WillBeThere.Backend.Context;
using WillBeThere.Backend.Repos;
using WillBeThere.Backend.Repos.WillBeThere;
using WillBeThere.Backend.Services;
using WillBeThere.Shared.Assemblers;
using WillBeThere.Shared.Assemblers.ResultModels;

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
            string connectionString = "server=localhost;userid=root;password=;database=willbethere;port=3307";
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
            services.AddScoped<IPublicSpaceRepo, PublicSpaceRepo<WillBeThereInMemoryContext>>();
            services.AddScoped<IAddressRepo, AddressRepo<WillBeThereInMemoryContext>>();
            services.AddScoped<IOrganizationRepo, OrganiozationRepo<WillBeThereInMemoryContext>>();
            services.AddScoped<IOrganizationAdminUserRepo,OrganizationAdminUserRepo<WillBeThereInMemoryContext>>();
            services.AddScoped<IOrganizationCategoryRepo,OrganizationCategoryRepo<WillBeThereInMemoryContext>>();
            services.AddScoped<IOrganizationProgramRepo, OrganizationProgramRepo<WillBeThereInMemoryContext>>();
            services.AddScoped<IParticipationRepo,ParticipationRepo<WillBeThereInMemoryContext>>();
            services.AddScoped<IRegisteredUserRepo,RegisteredUserRepo<WillBeThereInMemoryContext>>();

            services.AddScoped<IWrapRepo, WrapRepo>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IOrganizationProgramService, OrganizationProgramService>();
        }
    }
}
