﻿using WillBeThere.Shared.Models.Guids;

namespace WillBeThere.Shared.Models
{
    public class Organization : IDbEntity<Organization>
    {
        public Organization() 
        {
            Id=Guid.Empty;
            Name = string.Empty;
            Description = string.Empty;
            Url = string.Empty;
            Website = string.Empty;
            OrganizationCategoryId = new();
        }

        public Organization(Guid id, string name, string description, string url, string website, Guid? organizationCategoryId) 
        {
            Id=id;
            Name = name;
            Description = description;
            Url = url;
            Website = website;
            OrganizationCategoryId = organizationCategoryId;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Website { get; set; }
        public Guid? OrganizationCategoryId { get; set; }
        // 1:N Organization category - organization
        public virtual OrganizationCategory? OrganizationCategory { get; set; }
        public virtual List<OrganizationProgram>? OrganizationPrograms { get; set; }
        public virtual List<OrganizationAdminUser>? OrganizationsAdmins { get; set; }
        // N:M Organization - OrganizationAdminUser - RegisteredUsers
        public virtual ICollection<OrganizationAdminUser>? OrganizationAdmins { get; set; }

    }
}
