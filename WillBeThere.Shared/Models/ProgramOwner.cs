using WillBeThere.Shared.Models.Guids;

namespace WillBeThere.Shared.Models
{
    public class ProgramOwner : IDbEntity<ProgramOwner>
    {
        public ProgramOwner() 
        {
            Id = Guid.Empty;
        
        }

        public ProgramOwner(Guid id) 
        {
            Id = id;
        }
        public Guid Id { get; set; }
        // 1:1 Editor - ProgramOwner
        public virtual Editor? EditorData { get; set; }
        // 1:N ProgramOwner - OrganizationProgram
        public virtual List<OrganizationProgram>? OwnedPrograms { get; set; }
    }
}
