﻿using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Extensions
{
    public static class OrganizationExtension
    {
        public static OrganizationDto ToDto(this Organization model)
        {
            return new OrganizationDto()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Website = model.Website,
                Url = model.Url,
                OrganizationCategoryId = model.OrganizationCategoryId,

            };
        }

        public static Organization ToModel(this OrganizationDto dto)
        {
            return new Organization()
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Website = dto.Website,
                Url = dto.Url,
                OrganizationCategoryId = dto.OrganizationCategoryId,
            };
        }
    }
}
