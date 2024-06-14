namespace WillBeThere.Shared.Dtos
{
    public class ParticipationDto
    {
        public Guid Id { get; set; }
        public Guid RegisteredUserId { get; set; }
        public Guid OrganizationProgramId { get; set; }
        public int Evaluation { get; set; }
    }
}
