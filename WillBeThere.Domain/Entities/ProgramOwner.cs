using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WillBeThere.Domain.Entities.DbIds;

namespace WillBeThere.Domain.Entites
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
        [Key, ForeignKey(nameof(Editor))]
        [Required]
        public Guid Id { get; set; }
        // 1:1 Editor - ProgramOwner
        public virtual Editor? Editor { get; set; }
        // 1:N ProgramOwner - OrganizationProgram
        //public virtual List<OrganizationProgram>? OwnedPrograms { get; set; }
    }
}
