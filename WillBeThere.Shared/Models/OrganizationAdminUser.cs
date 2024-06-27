using WillBeThere.Shared.Models.DbIds;

namespace WillBeThere.Shared.Models
{
    public class OrganizationAdminUser : IDbEntity<OrganizationAdminUser>
    {
        public OrganizationAdminUser() 
        {
            Id = new DbId();
            AdminId = new();
            OrganizationId = new();
        }

        public OrganizationAdminUser(DbId id, DbId adminId, DbId organizationId) 
        {
            Id = id;
            AdminId = adminId;
            OrganizationId = organizationId;
        }
        public DbId Id { get; set; }
        public DbId AdminId { get; set; }
        public DbId OrganizationId { get; set; }
        public virtual List<OrganizationProgram>? OrganizationPrograms { get; set; }
        public virtual RegisteredUser? Admin { get; set; }
        public virtual Organization? Organization { get; set; }

    }
}
