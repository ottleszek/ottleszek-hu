using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WillBeThere.Shared.Models.Guids;

namespace WillBeThere.Shared.Models
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
        [Required]
        public Guid RegisteredUserId;

        // 1:1 Editor - RegisteredUser
        public virtual RegisteredUser? RegisteredUser { get; set; }
        // 1:N Editor - OrganizationEditor
        //public virtual List<OrganizationEditor>? EditedOrganizations { get; set; }
    }
}
