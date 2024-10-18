﻿using WillBeThere.DomainLayer.Entites;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.DataServices;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.MapperServices;
using WillBeThere.ApplicationLayer.Transformers.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base.DataService
{
    public class BaseOrganizationCategoryDataService : BaseDataService<OrganizationCategory, OrganizationCategoryDto, OrganizationCategoryAssembler>, IBaseOrganizationCategoryDataService
    {
        public BaseOrganizationCategoryDataService(IBaseOrganizationCategoryMapperService? mapperService) : base(mapperService)
        {
        }
    }
}