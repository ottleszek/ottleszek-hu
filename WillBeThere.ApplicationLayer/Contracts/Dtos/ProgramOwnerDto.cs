﻿namespace WillBeThere.ApplicationLayer.Contracts.Dtos
{
    public class ProgramOwnerDto
    {
        public Guid Id { get; set; } = Guid.Empty;
        public Guid AdminId { get; set; } = Guid.Empty;
        public Guid OrganizationId { get; set; } = Guid.Empty;
    }
}