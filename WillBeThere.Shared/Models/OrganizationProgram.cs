namespace WillBeThere.Shared.Models
{
    public class OrganizationProgram : IDbEntity<OrganizationProgram>
    {
        public OrganizationProgram()
        {
            Id = Guid.Empty;
            Title = string.Empty;
            Start = DateTime.Now;
            End = null;
            IsPublic = false;
            IsDeffered = false;
            OrganizationOwnerId = Guid.Empty;
            ProgramOwnerId = Guid.Empty;
            AddressId = Guid.Empty;
            Organization = new Organization();
            ProgramOwner = new RegisteredUser();
            ProgramCategories=new List<OrganizationProgramCategories>();
            
        }

        public OrganizationProgram(Guid id, string title, DateTime start, DateTime? end, bool isPublic, bool isDeffered, Guid orgranizationOwnerId, Guid prgromOwnerId, Guid? addressId)
        {
            Id = id;
            Title = title;
            Start = start;
            End = end;
            IsPublic = isPublic;
            IsDeffered = isDeffered;
            OrganizationOwnerId = orgranizationOwnerId;
            ProgramOwnerId = prgromOwnerId;
            AddressId = addressId;
            Organization=new Organization();
            ProgramOwner=new RegisteredUser();
            ProgramCategories = new List<OrganizationProgramCategories>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Start {  get; set; }
        public DateTime? End { get; set; }
        public bool IsPublic { get; set; }
        public bool IsDeffered { get; set; }
        public Guid OrganizationOwnerId { get; set; }
        public Guid ProgramOwnerId {  get; set; }
        public Guid? AddressId { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual RegisteredUser ProgramOwner { get; set; }
        public virtual Address? Address { get; set; }
        public virtual ICollection<Participation>? ProgrammeParticipants { get; set; }
        public virtual ICollection<OrganizationProgramCategories> ProgramCategories { get; set; }
    }
}
