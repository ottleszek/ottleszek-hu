using Shared.DomainLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace WillBeThere.DomainLayer.Entites
{
    public class OrganizationCategory :  IDbEntity<OrganizationCategory>, IEquatable<OrganizationCategory>
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

        [Key]
        [Required]
        public Guid Id { get ; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        public virtual ICollection<Organization>? Organizations { get; set; }

        public bool Equals(OrganizationCategory? other)
        {
            if (other == null) return false;
            return Name == other.Name;
        }        
    }
}
