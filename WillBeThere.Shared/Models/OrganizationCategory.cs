using WillBeThere.Shared.Models.Guids;

namespace WillBeThere.Shared.Models
{
    public class OrganizationCategory :  IDbEntity<OrganizationCategory>
    {
        public OrganizationCategory()
        {
            Id = Guid.Empty;
            Name = string.Empty;
        }
        public OrganizationCategory(Guid id, string name) 
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get ; set; }
        public string Name { get; set; }
        //public virtual ICollection<Organization>? Organizations { get; set; }
    }
}
