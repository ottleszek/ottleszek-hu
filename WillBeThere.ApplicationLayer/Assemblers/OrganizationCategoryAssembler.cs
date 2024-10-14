﻿using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Extensions.ModelExtensions;
using SharedApplicationLayer.Assamblers;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;

namespace WillBeThere.ApplicationLayer.Assemblers
{
    public class OrganizationCategoryAssembler : IAssembler<OrganizationCategory, OrganizationCategoryDto>
    {
        public OrganizationCategoryDto ToDto(OrganizationCategory model)
        {
            return model.ToDto();
        }

        public OrganizationCategory ToModel(OrganizationCategoryDto dto)
        {
            return dto.ToModel();
        }
    }
}
