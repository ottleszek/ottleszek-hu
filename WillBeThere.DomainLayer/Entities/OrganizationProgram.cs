using Shared.DomainLayer.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WillBeThere.DomainLayer.Entites
{
    public class OrganizationProgram :  IDbEntity<OrganizationProgram>
    {
        public OrganizationProgram() 
        {
            Id=Guid.Empty;
            Title = string.Empty;
            Description = string.Empty;
            Start = DateTime.Now;
            End = null;
            IsPublic = false;
            IsDeffered = false;
            OrganizationId = new();
            ProgramOwnerId = new();
            AddressId = new();
            
        }

        public OrganizationProgram(Guid id, string title, string description, DateTime start, DateTime? end, bool isPublic, bool isDeffered, Guid organizationOwnerId, Guid programOwnerId, Guid addressId) 
        {
            Id= id;
            Title = title;
            Description = description;
            Start = start;
            End = end;
            IsPublic = isPublic;
            IsDeffered = isDeffered;
            OrganizationId = organizationOwnerId;
            ProgramOwnerId = programOwnerId;
            AddressId = addressId;
        }
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime Start {  get; set; }
        public DateTime? End { get; set; }
        [Required]
        public bool IsPublic { get; set; }
        public bool IsDeffered { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid ProgramOwnerId {  get; set; }
        public Guid AddressId { get; set; }

        [ForeignKey(nameof(OrganizationId))]
        public virtual Organization? Organization { get; set; }
        // 1:1 OrganizationProgram - ProgramOwner
        //public virtual ProgramOwner? ProgramOwner { get; set; }
        // 1:1 OrganizationProgram - Address
        [ForeignKey(nameof(AddressId))]
        public virtual Address? Address { get; set; }
        // 1:N OrganizationProgram - Participation
        public virtual ICollection<Participation>? Participants { get; set; }
        

    }
}
