﻿using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Dtos.ResultModels
{
    public class PublicOrganizationProgramDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public Guid OrganizationId { get; set; }
        public string Organization { get; set; } = string.Empty;
        public Address Address { get; set; } = new Address();
        public string PublicSpaceName { get; set; } = string.Empty;
    }
}
