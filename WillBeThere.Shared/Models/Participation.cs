using WillBeThere.Shared.Models.Guids;

namespace WillBeThere.Shared.Models
{
    public class Participation : IDbEntity<OrganizationProgram>
    {
        public Participation()
        {
            Id = Guid.Empty;
            RegisteredUserId =Guid.Empty;
            OrganizationProgramId = Guid.Empty;
            Evaluation = -1;
        }
        public Participation(Guid id, Guid registeredUserID, Guid orgranizationProgramId, int evaluation) 
        {
            Id=id;
            RegisteredUserId = registeredUserID;
            OrganizationProgramId = orgranizationProgramId;
            Evaluation = evaluation;
        }

        public Guid Id { get; set; }
        public Guid RegisteredUserId { get; set; }
        public Guid OrganizationProgramId { get; set; }
        public int Evaluation {  get; set; }
        public virtual RegisteredUser? Participant { get; set; }
        public virtual OrganizationProgram? OrganizationProgram { get; set; }
        
    }
}
