using WillBeThere.Shared.Models.DbIds;

namespace WillBeThere.Shared.Models
{
    public class OrganizationCategory :  IDbEntity<OrganizationCategory>
    {
        public OrganizationCategory()
        {
            Id = new DbId();
            Name = string.Empty;
        }
        public OrganizationCategory(DbId id, string name) 
        {
            Id = id;
            Name = name;
        }

        public DbId Id { get ; set; }
        public string Name { get; set; }
        public virtual ICollection<Organization>? Organizations { get; set; }

    }
}
