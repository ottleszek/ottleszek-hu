﻿using WillBeThere.Shared.Models.Guids;

namespace WillBeThere.Shared.Dtos
{
    public class OrganizationCategoryDto
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
