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
            ProgramCategoryId = Guid.Empty;
            AddressId = Guid.Empty;
            Organization = new Organization();
            ProgramOwner = new RegisteredUser();
            ProgramCategory=new ProgramCategory();
            
        }

        public OrganizationProgram(Guid id, string title, DateTime start, DateTime? end, bool isPublic, bool isDeffered, Guid orgranizationOwnerId, Guid prgromOwnerId, Guid programCategoryId, Guid? addressId)
        {
            Id = id;
            Title = title;
            Start = start;
            End = end;
            IsPublic = isPublic;
            IsDeffered = isDeffered;
            OrganizationOwnerId = orgranizationOwnerId;
            ProgramOwnerId = prgromOwnerId;
            ProgramCategoryId = programCategoryId;
            AddressId = addressId;
            Organization=new Organization();
            ProgramOwner=new RegisteredUser();
            ProgramCategory = new ProgramCategory();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Start {  get; set; }
        public DateTime? End { get; set; }
        public bool IsPublic { get; set; }
        public bool IsDeffered { get; set; }
        public Guid OrganizationOwnerId { get; set; }
        public Guid ProgramOwnerId {  get; set; }
        public Guid ProgramCategoryId { get; set; }
        public Guid? AddressId { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual RegisteredUser ProgramOwner { get; set; }
        public virtual ProgramCategory ProgramCategory { get; set; }
        public virtual Address? Address { get; set; }
        public virtual ICollection<Participation>? Participation { get; set; }
    }
}
