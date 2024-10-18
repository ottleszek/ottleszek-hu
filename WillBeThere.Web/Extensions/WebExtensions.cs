using SharedApplicationLayer.Contracts.Persistence;
using SharedApplicationLayer.Repos;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.DataServices;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.HttpServices;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.MapperServices;
using WillBeThere.ApplicationLayer.Contracts.UnitOfWork;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;
using WillBeThere.ApplicationLayer.Repos.QueryRepo;
using WillBeThere.ApplicationLayer.Transformers.Converters;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Services.Base;
using WillBeThere.InfrastuctureLayer.Context;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.Base;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.UnifOfWorks;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos.Repos;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos;
using WillBeThere.InfrastuctureLayer.Implementations.Services;
using WillBeThere.InfrastuctureLayer.Persistence.Services.Http;
using WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base.DataService;
using WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base.HttpService;
using WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base.MapperService;
using Microsoft.EntityFrameworkCore;


namespace WillBeThere.Web.Extensions
{
    public static class WebExtensions
    {
        public static void ConfigureWebServices(this IServiceCollection services)
        {           
            services.AddScoped<IDataPersistenceService, DataPersistenceService>();            
        }
    }
}
