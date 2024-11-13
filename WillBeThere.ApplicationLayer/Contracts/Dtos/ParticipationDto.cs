using Shared.DomainLayer.Entities;

namespace WillBeThere.ApplicationLayer.Contracts.Dtos
{
    public class ParticipationDto : IDbEntity<ParticipationDto>
    {
        public Guid Id { get; set; } = Guid.Empty;
        public Guid RegisteredUserId { get; set; } = Guid.Empty;
        public Guid OrganizationProgramId { get; set; } = Guid.Empty;
        public int Evaluation { get; set; }
    }
}
