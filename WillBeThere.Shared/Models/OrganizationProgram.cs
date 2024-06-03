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
            OrgranizationId = Guid.Empty;
            RegisteredUserId = Guid.Empty;
            ProgramCategoryId = Guid.Empty;
            AddressId = Guid.Empty;
            Orgranization = new Organization();
            RegisteredUser = new RegisteredUser();
        }

        public OrganizationProgram(Guid id, string title, DateTime start, DateTime? end, bool isPublic, bool isDeffered, Guid orgranizationId, Guid registeredUserId, Guid? programCategoryId, Guid? addressId)
        {
            Id = id;
            Title = title;
            Start = start;
            End = end;
            IsPublic = isPublic;
            IsDeffered = isDeffered;
            OrgranizationId = orgranizationId;
            RegisteredUserId = registeredUserId;
            ProgramCategoryId = programCategoryId;
            AddressId = addressId;
            Orgranization=new Organization();
            RegisteredUser=new RegisteredUser();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Start {  get; set; }
        public DateTime? End { get; set; }
        public bool IsPublic { get; set; }
        public bool IsDeffered { get; set; }
        public Guid OrgranizationId { get; set; }
        public Guid RegisteredUserId {  get; set; }
        public Guid? ProgramCategoryId { get; set; }
        public Guid? AddressId { get; set; }
        public virtual Organization Orgranization { get; set; }
        public virtual RegisteredUser RegisteredUser { get; set; }
        public virtual ProgramCategory? ProgramCategory { get; set; }
        public virtual Address? Address { get; set; }

        public bool HasId => Id !=Guid.Empty;
    }
}
