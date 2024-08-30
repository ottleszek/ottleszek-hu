using WillBeThere.Shared.Models.Guids;

namespace WillBeThere.Shared.Models
{
    public class OrganizationEditor : IDbEntity<OrganizationEditor>
    {
        public Guid Id { get; set ; }
        private Guid OrganizationId { get; set ; }
        private Guid EditorId { get; set ; }
        // 1:N Organization - OrganizationEditor
        public virtual Organization? Organization { get; set ; }
        public virtual Editor? Editor { get; set ; }

    }
}
