using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WillBeThere.Shared.Models.Guids;

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
        // virtual List<OrganizationProgram>? OrganizationPrograms { get; set; }
        // 1:N Organization - OrganizationEditor
        //public virtual ICollection<Editor>? OrganizationEditors{ get; set; }

    }
}
