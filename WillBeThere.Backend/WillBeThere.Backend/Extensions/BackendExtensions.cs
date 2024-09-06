using Microsoft.EntityFrameworkCore;
using WillBeThere.Application.Assemblers;
using WillBeThere.Domain.Assemblers.ResultModels;
using WillBeThere.Infrastucture.Context;
using WillBeThere.Infrastucture.Implementations.Repos.BaseRepos;
using WillBeThere.Infrastucture.Implementations.Repos.WillBeThere;
using WillBeThere.Infrastucture.Implementations.Services;

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
    }
}
