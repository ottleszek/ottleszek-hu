using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WillBeThere.Domain.Entities.DbIds;

namespace WillBeThere.Domain.Entites
{
    public class OrganizationEditor : IDbEntity<OrganizationEditor>
    {
        [Key]
        [Required]
        public Guid Id { get; set ; }
        public Guid OrganizationId { get; set ; }
        public Guid EditorId { get; set ; }
        // N:M Organization - OrganizationEditor - Editor
        [ForeignKey(nameof(OrganizationId))]
        public virtual Organization? Organization { get; set ; }
        [ForeignKey(nameof(EditorId))]
        public virtual Editor? Editor { get; set ; }

    }
}
