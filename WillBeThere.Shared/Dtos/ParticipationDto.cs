using WillBeThere.Shared.Models.DbIds;

namespace WillBeThere.Shared.Dtos
{
    public class ParticipationDto
    {
        public DbId Id { get; set; } = new DbId();
        public DbId RegisteredUserId { get; set; } = new DbId();
        public DbId OrganizationProgramId { get; set; } =new DbId();
        public int Evaluation { get; set; }
    }
}
