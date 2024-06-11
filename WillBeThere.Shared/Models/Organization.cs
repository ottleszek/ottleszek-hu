namespace WillBeThere.Shared.Models
{
    public class Organization : IDbEntity<Organization>
    {
        public Organization()
        {
            Id = Guid.Empty;
            Name = string.Empty;
            Description = string.Empty;
            Url = string.Empty;
            Website = string.Empty;
        }

        public Organization(Guid id, string name, string description, string url, string website)
        {
            Id = id;
            Name = name;
            Description = description;
            Url = url;
            Website = website;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Website { get; set; }
        public Guid? OrganizationCategoryId { get; set; }
        public virtual OrganizationCategory? OrganizationCategory { get; set; }
        public virtual List<OrganizationProgram>? OrganizationPrograms { get; set; }
        public virtual List<OrganizationAdminUser>? OrganizationAdminUsers { get; set; }
    }
}
