using WillBeThere.Shared.Models.DbIds;

namespace WillBeThere.Shared.Models
{
    public class Participation : IDbEntity<OrganizationProgram>
    {
        public Participation()
        {
            Id=new DbId();
            RegisteredUserId = new DbId();
            OrganizationProgramId = new DbId();
            Evaluation = -1;
        }
        public Participation(DbId id, DbId registeredUserID, DbId orgranizationProgramId, int evaluation) 
        {
            Id=id;
            RegisteredUserId = registeredUserID;
            OrganizationProgramId = orgranizationProgramId;
            Evaluation = evaluation;
        }

        public DbId Id { get; set; }
        public DbId RegisteredUserId { get; set; }
        public DbId OrganizationProgramId { get; set; }
        public int Evaluation {  get; set; }
        public virtual RegisteredUser? Participant { get; set; }
        public virtual OrganizationProgram? OrganizationProgram { get; set; }
        
    }
}
