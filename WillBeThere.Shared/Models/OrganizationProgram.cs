namespace WillBeThere.Shared.Models
{
    public class OrganizationProgram : IDbEntity<OrganizationProgram>
    {
        public OrganizationProgram(Guid id, string title, DateTime start, DateTime end, bool isPublic, bool isDeffered, Guid? addressId, Guid? categoryId)
        {
            Id = id;
            Title = title;
            Start = start;
            End = end;
            IsPublic = isPublic;
            IsDeffered = isDeffered;
            AddressId = addressId;
            ProgramCategoryId = categoryId;
        }

        public OrganizationProgram()
        {
            Id = Guid.Empty;
            Title = string.Empty;
            Start = DateTime.Now;
            End = null;
            IsPublic = false;
            IsDeffered = false;
            AddressId = null;
            ProgramCategoryId = null;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Start {  get; set; }
        public DateTime? End { get; set; }
        public bool IsPublic { get; set; }
        public bool IsDeffered { get; set; }
        public Guid OrgranizationId { get; set; }
        public virtual Organization Orgranization { get; set; }
        public virtual OrganizationProgram OrgranizationProgram { get; set; }
        public Guid RegisteredUserId {  get; set; }
        public virtual RegisteredUser RegisteredUser { get; set; }
        public Guid? ProgramCategoryId { get; set; }
        public virtual ProgramCategory? ProgramCategory { get; set; }
        public Guid? AddressId { get; set; }
        public virtual Address? Address { get; set; }

        public bool HasId => Id !=Guid.Empty;
    }
}
