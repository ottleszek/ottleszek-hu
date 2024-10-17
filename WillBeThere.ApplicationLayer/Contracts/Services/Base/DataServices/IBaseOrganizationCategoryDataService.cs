﻿using SharedApplicationLayer.Contracts.Services;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.ApplicationLayer.Transformers.Assemblers;
using WillBeThere.DomainLayer.Entites;


namespace WillBeThere.ApplicationLayer.Contracts.Services.Base.DataServices
{
    public interface IBaseOrganizationCategoryDataService : IBaseDataService<OrganizationCategory, OrganizationCategoryDto, OrganizationCategoryAssembler>
    {
    }
}
