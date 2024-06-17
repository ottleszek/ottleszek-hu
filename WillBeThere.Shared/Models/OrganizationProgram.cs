namespace WillBeThere.Shared.Models
{
    public class OrganizationProgram : IDbEntity<OrganizationProgram>
    {
        public OrganizationProgram()
        {
            Id = Guid.Empty;
            Title = string.Empty;
            Description = string.Empty;
            Start = DateTime.Now;
            End = null;
            IsPublic = false;
            IsDeffered = false;
            OrganizationOwnerId = Guid.Empty;
            ProgramOwnerId = Guid.Empty;
            AddressId = Guid.Empty;
            Organization = null;
            
        }

        public OrganizationProgram(Guid id, string title, string description, DateTime start, DateTime? end, bool isPublic, bool isDeffered, Guid organizationOwnerId, Guid programOwnerId, Guid? addressId)
        {
            Id = id;
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

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start {  get; set; }
        public DateTime? End { get; set; }
        public bool IsPublic { get; set; }
        public bool IsDeffered { get; set; }
        public Guid OrganizationOwnerId { get; set; }
        public Guid ProgramOwnerId {  get; set; }
        public Guid? AddressId { get; set; }
        public virtual Organization? Organization { get; set; }
        public virtual OrganizationAdminUser? ProgramOwner { get; set; }
        public virtual Address? Address { get; set; }
        public virtual ICollection<Participation>? ProgramParticipants { get; set; }
    }
}
