﻿using WillBeThere.Application.Dtos;

namespace WillBeThere.HttpService.HttpService
{
    public class OrganizationCategoryHttpService : BaseHttpService<OrganizationCategoryDto>, IOrganizationCategoryHttpService
    {
        public OrganizationCategoryHttpService(IHttpClientFactory? httpClientFactory) : base(httpClientFactory)
        {
        }
    }
}
