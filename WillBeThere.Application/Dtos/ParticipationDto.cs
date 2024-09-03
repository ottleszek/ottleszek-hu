namespace WillBeThere.Application.Dtos
{
    public class ParticipationDto
    {
        public Guid Id { get; set; } = Guid.Empty;
        public Guid RegisteredUserId { get; set; } = Guid.Empty;
        public Guid OrganizationProgramId { get; set; } = Guid.Empty;
        public int Evaluation { get; set; }
    }
}
