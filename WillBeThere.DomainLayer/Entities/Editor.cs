using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WillBeThere.DomainLayer.Entities.DbIds;


namespace WillBeThere.DomainLayer.Entites
{
    public class Editor : IDbEntity<Editor>
    {
        public Editor()
        {
            Id = Guid.Empty;
        }

        // https://medium.com/@jasminewith/entity-framework-core-one-to-one-relationship-50b695634423

        [Key, ForeignKey(nameof(RegisteredUser))]
        [Required]
        public Guid Id { get; set; }

        // 1:1 Editor - RegisteredUser
        public virtual RegisteredUser? RegisteredUser { get; set; }
        // 1:1 Editor - ProgramOwner
        public virtual ProgramOwner? ProgramOwner { get; set; }
        // N:M Editor -= OrganizationEditor - Organization
        public virtual List<OrganizationEditor>? Organizations { get; set; }

    }
}
