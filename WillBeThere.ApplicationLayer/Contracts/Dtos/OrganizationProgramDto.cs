using Shared.DomainLayer.Entities;

namespace WillBeThere.ApplicationLayer.Contracts.Dtos
{
    public class OrganizationProgramDto : IDbEntity<OrganizationProgramDto>
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Title { get; set; } = string.Empty;
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public bool IsPublic { get; set; }
        public bool IsDeffered { get; set; }
        public Guid OrganizationOwnerId { get; set; } = Guid.Empty;
        public Guid ProgramOwnerId { get; set; } = Guid.Empty;
        public Guid AddressId { get; set; }
    }
}
