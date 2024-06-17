namespace WillBeThere.Shared.Dtos
{
    public class OrganizationProgramDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public bool IsPublic { get; set; }
        public bool IsDeffered { get; set; }
        public Guid OrganizationOwnerId { get; set; }
        public Guid ProgramOwnerId { get; set; }
        public Guid? AddressId { get; set; }
    }
}
