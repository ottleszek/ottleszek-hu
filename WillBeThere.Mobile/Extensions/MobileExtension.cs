﻿using WillBeThere.HttpService.DataService;
using WillBeThere.HttpService.HttpService;
using WillBeThere.HttpService.MapperService;
using WillBeThere.Mobile.ViewModel;
using WillBeThere.Shared.Assemblers.ResultModels;
using WillBeThere.Shared.Assemblers;
using static System.Net.WebRequestMethods;

namespace WillBeThere.Mobile.Extensions
{
    public static class MobileExtension
    {
        public static void ConfigureHttpCliens(this IServiceCollection services)
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