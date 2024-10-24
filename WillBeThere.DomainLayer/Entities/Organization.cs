using Shared.DomainLayer.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WillBeThere.DomainLayer.Entites
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
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Website { get; set; }
        public Guid? OrganizationCategoryId { get; set; }
        // 1:N Organization category - organization
        [ForeignKey(nameof(OrganizationCategoryId))]
        public virtual OrganizationCategory? OrganizationCategory { get; set; }
        // 1:N Organization - OrganizationProgram
        public virtual ICollection<OrganizationProgram>? OrganizationPrograms { get; set; }
        // N:M Organization -= OrganizationEditor - Editor
        public virtual List<OrganizationEditor>? Editors { get; set; }

    }
}
