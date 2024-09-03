﻿using WillBeThere.HttpService.DataService;
using WillBeThere.HttpService.HttpService;
using WillBeThere.HttpService.MapperService;
using WillBeThere.Mobile.ViewModels;
using WillBeThere.Domain.Assemblers.ResultModels;
using WillBeThere.Application.Assemblers;

namespace WillBeThere.Mobile.Extensions
{
    public static class MobileExtensions
    {
        public static void ConfigureHttpClient(this IServiceCollection services)
        {
            var baseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:6070/" : "http://localhost:6070/";                                

            services.AddHttpClient("WillBeThere", options =>
            {
                options.BaseAddress = new Uri($"{baseUrl}");
            });
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
            services.AddTransient<MainPageViewModel>();
        }

        public static void ConfigurePages(this IServiceCollection services)
        {
            services.AddSingleton<MainPage>();
        }
    }
}
