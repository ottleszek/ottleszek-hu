using WillBeThere.Shared.Models.Guids;

namespace WillBeThere.Shared.Models
{
    public class Editor : IDbEntity<Editor>
    {
        public Guid Id { get; set; }
        public Editor()
        {
            Id = Guid.Empty;
        }

        // 1:1 Editor - RegisteredUser
        //public virtual RegisteredUser? RegisteredUser { get; set; }
        // 1:N Editor - OrganizationEditor
        //public virtual List<OrganizationEditor>? EditedOrganizations { get; set; }
    }
}
