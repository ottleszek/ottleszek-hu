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
        public virtual List<OrganizationProgram>? Programs { get; set; }

        public bool HasId => Id != Guid.Empty;
    }
}
