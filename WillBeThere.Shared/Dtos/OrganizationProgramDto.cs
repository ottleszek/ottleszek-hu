using WillBeThere.Shared.Models.DbIds;

namespace WillBeThere.Shared.Dtos
{
    public class OrganizationProgramDto
    {
        public DbId Id { get; set; } = new DbId();
        public string Title { get; set; } = string.Empty;
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public bool IsPublic { get; set; }
        public bool IsDeffered { get; set; }
        public DbId OrganizationOwnerId { get; set; } = new DbId();
        public DbId ProgramOwnerId { get; set; } = new DbId();
        public DbId? AddressId { get; set; }
    }
}
