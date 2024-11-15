﻿using Microsoft.Extensions.DependencyInjection;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.InfrastuctureLayer.Context;
using WillBeThere.ApplicationLayer.Transformers.Assemblers;
using WillBeThere.ApplicationLayer.Transformers.Assemblers.ResultModels;
using WillBeThere.ApplicationLayer.Transformers.Converters;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos;
using Shared.ApplicationLayer.Transformers;
using Shared.ApplicationLayer.Repos;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.HttpRepo;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.MapperRepo;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.MappreRepo;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.ModelRepo;
using Shared.ApplicationLayer.Repos.UnitOfWork;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.ApplicationLayer.Contracts.Dtos.ResultModels;
using WillBeThere.DomainLayer.Entites.ResultModels;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.WillBeThere;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.WrapRepo;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.WillBeThere.Backend;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WillBeThere.InfrastuctureLayer.Adapters.Repos.Http.MapperRepo.Query;
using WillBeThere.InfrastuctureLayer.Adapters.Repos.Http.ModelRepo.Query;
using WillBeThere.InfrastuctureLayer.Adapters.Repos.Http.Query;
using WillBeThere.InfrastuctureLayer.Persistence.UnifOfWorks;
using Shared.InfrastuctureLayer.Persistence.Repos;
using Shared.InfrastuctureLayer.Persistence.Repos.Commands;
using Shared.InfrastuctureLayer.Persistence.Context;
using Microsoft.Data.Sqlite;
using System.Xml.Linq;

namespace WillBeThere.InfrastuctureLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.ConfigureHttpClient();
            services.ConfigureAssamblers();
            services.ConfigureConverters();
            services.ConfigureRepos();
            services.ConfigureServices();
            services.ConfigurePersistence();

            //services.ConfigureInMemoryContext();
            //services.ConfigureMysqlContext();
            services.ConfigureSqlliteSharedInMemoryContext();
            return services;
        }

        public static void ConfigureSqlliteSharedInMemoryContext(this IServiceCollection services)
        {
            var connectionString = "DataSource=willbethere.db";
            var keepAliveConnection = new SqliteConnection(connectionString);
            keepAliveConnection.Open();

            services.AddDbContext<WillBeThereInMemoryContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddDbContext<IdentityContext>
            (
                options =>
                {
                    options.UseSqlite(connectionString);
                }
            );

            /*var connectionString = "DataSource=willbethereshareddb;mode=memory;cache=shared";
            var keepAliveConnection = new SqliteConnection(connectionString);
            keepAliveConnection.Open();

            services.AddDbContext<WillBeThereSqliteSheredInMemoryContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            */
        }
        public static void ConfigureInMemoryContext(this IServiceCollection services)
        {
            string dbName = "WillBeThere" + Guid.NewGuid();
            services.AddDbContext<WillBeThereInMemoryContext>(
                options =>
                {
                    options.UseInMemoryDatabase(databaseName: dbName);
                    options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
                }
            );

            services.AddDbContext<IdentityContext>
                (
                    options =>
                    {
                        options.UseInMemoryDatabase(databaseName: dbName);
                        options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
                    }
                );

        }


        public static void ConfigureMysqlContext(this IServiceCollection services)
        {
            string connectionString = "server=localhost;userid=root;password=;database=willbethere;port=3306";
            services.AddDbContext<WillBeThereMysqlContext>(options => options.UseMySQL(connectionString));
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
            services.AddScoped<IAssembler<Address, AddressDto>,AddressAssembler>();
            services.AddScoped<IAssembler<Editor, EditorDto>, EditorAssambler>();
            services.AddScoped<IAssembler<Organization, OrganizationDto>, OrganizationAssembler>();
            services.AddScoped<IAssembler<OrganizationCategory, OrganizationCategoryDto>, OrganizationCategoryAssembler >();
            services.AddScoped<IAssembler<OrganizationProgram, OrganizationProgramDto>, OrganizationProgramAssembler>();
            services.AddScoped<IAssembler<Participation, ParticipationDto>, PartipationAssembler>();
            services.AddScoped<IAssembler<PublicSpace, PublicSpaceDto>, PublicSpaceAssembler>();
            services.AddScoped<IAssembler<ProgramOwner, ProgramOwnerDto>, ProgramOwnerAssembler>();
            services.AddScoped<IAssembler<PublicOrganizationProgram, PublicOrganizationProgramDto>, PublicOrganizationProgramAssembler>();
            services.AddScoped<IAssembler<RegisteredUser, RegisteredUserDto>,RegisteredUserAssembler>();
        }

        public static void ConfigureConverters(this IServiceCollection services)
        {
            services.AddScoped<IDomainDtoConterter<OrganizationCategory, OrganizationCategoryDto>, DomainDtoConverter<OrganizationCategory, OrganizationCategoryDto, OrganizationCategoryAssembler>>();
            services.AddScoped<OrganizationCategoryDomainDtoConverter>();
        }

        public static void ConfigureRepos(this IServiceCollection services)
        {
            services.AddScoped<IOrganizationCategoryQueryModelRepo, OrganizationCategoryQueryModelRepo > ();


            if (true)
            {
                services.AddScoped<IBaseDbRepo, BaseDbRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IBaseCommandDbRepo, BaseCommandDbRepo<WillBeThereInMemoryContext>>();

                services.AddScoped<IAddressDbQueryRepo, AddressDbQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IEditorDbQueryRepo, EditorDbQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationCategoryDbQueryRepo, OrganizationCategoryDbQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationEditorDbQueryRepo, OrganizationEditorDbQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationProgramDbQueryRepo, OrganizationProgramDbQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationDbQueryRepo, OrganizationDbQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IParticipationDbQueryRepo, ParticipationDbQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IProgamOwnerDbQueryRepo, ProgramOwnerDbQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IPublicSpaceDbQueryRepo, PublicSpaceDbQueryRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IRegisteredUserDbQueryRepo, RegisteredUserDbQueryRepo<WillBeThereInMemoryContext>>();

                services.AddScoped<IAddressCommandRepo, AddressDbCommandRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IEditorCommandRepo, EditorDbCommandRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationCategoryCommandRepo, OrganizationCategoryDbCommandRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationEditorCommandRepo, OrganizationEditorDbCommandRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationProgramCommandRepo, OrganizationProgramDbCommandRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IOrganizationCommandRepo, OrganizationDbCommandRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IParticipationCommandRepo, ParticipationCommandDbRepoo<WillBeThereInMemoryContext>>();
                services.AddScoped<IProgamOwnerCommandRepo, ProgramOwnerDbCommandRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IPublicSpaceCommandRepo, PublicSpaceDbCommandRepo<WillBeThereInMemoryContext>>();
                services.AddScoped<IRegisteredUserCommandRepo, RegisteredUserDbCommandRepo<WillBeThereInMemoryContext>>();

                services.AddScoped<IUnitOfWork, UnitOfWork<WillBeThereInMemoryContext>>();
                services.AddScoped<IWillBeThereWrapQueryUnitOfWork,WillBeThereWrapQueryUnitOfWork<WillBeThereInMemoryContext>>();
            }
            else
            {
            }
        }


        public static void ConfigureServices(this IServiceCollection services)
        {
            // HttpService
            services.AddScoped<IOrganizationProgramQueryHttpRepo, OrganizationProgramQueryHttpRepo>();
            services.AddScoped<IOrganizationCategoryQueryHttpRepo, OrganizationCategoryQueryHttpRepo>();

            // MapperService
            services.AddScoped<IOrganizationProgramQueryMapperRepo, OrganizationProgramQueryMapperRepo>();
            services.AddScoped<IOrganizationCategoryQueryMapperRepo, OrganizationCategoryQueryMapperRepo>();

            // ModelService
            services.AddScoped<IOrganizationProgramQueryModelRepo, OrganizationProgramQueryModelRepo>();
            services.AddScoped<IOrganizationCategoryQueryModelRepo, OrganizationCategoryQueryModelRepo>();
        }

        public static void ConfigurePersistence(this IServiceCollection services)
        {
            //services.AddScoped<IManyDataPersistenceService<OrganizationCategory>, ManyDataGenericPersistenceService<OrganizationCategory, OrganizationCategoryDto>>();
        }
    }
}