﻿namespace WillBeThere.Shared.Dtos
{
    public class OrganizationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } =string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public Guid? OrganizationCategoryId { get; set; }
    }
}
