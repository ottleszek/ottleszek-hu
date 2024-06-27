using WillBeThere.Shared.Models.DbIds;

namespace WillBeThere.Shared.Models
{
    public class OrganizationProgram :  IDbEntity<OrganizationProgram>
    {
        public OrganizationProgram() 
        {
            Id=new DbId();
            Title = string.Empty;
            Description = string.Empty;
            Start = DateTime.Now;
            End = null;
            IsPublic = false;
            IsDeffered = false;
            OrganizationOwnerId = new();
            ProgramOwnerId = new();
            AddressId = new();
            Organization = null;
            
        }

        public OrganizationProgram(DbId id, string title, string description, DateTime start, DateTime? end, bool isPublic, bool isDeffered, DbId organizationOwnerId, DbId programOwnerId, DbId? addressId) 
        {
            Id= id;
            Title = title;
            Description = description;
            Start = start;
            End = end;
            IsPublic = isPublic;
            IsDeffered = isDeffered;
            OrganizationOwnerId = organizationOwnerId;
            ProgramOwnerId = programOwnerId;
            AddressId = addressId;
        }
        public DbId Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start {  get; set; }
        public DateTime? End { get; set; }
        public bool IsPublic { get; set; }
        public bool IsDeffered { get; set; }
        public DbId OrganizationOwnerId { get; set; }
        public DbId ProgramOwnerId {  get; set; }
        public DbId? AddressId { get; set; }
        public virtual Organization? Organization { get; set; }
        public virtual OrganizationAdminUser? ProgramOwner { get; set; }
        public virtual Address? Address { get; set; }
        public virtual ICollection<Participation>? ProgramParticipants { get; set; }

    }
}
