
namespace WillBeThere.Shared.Models
{
    public class OrganizationAdminUser : IDbEntity<OrganizationAdminUser>
    {
        public OrganizationAdminUser()
        {
            Id = Guid.Empty;
            AdminId = Guid.Empty;
            OrganizationId = Guid.Empty;
            Admin=new RegisteredUser();
            Organization=new Organization();
        }

        public OrganizationAdminUser(Guid id, Guid adminId, Guid organizationId)
        {
            Id = id;
            AdminId = adminId;
            OrganizationId = organizationId;
            Admin = new RegisteredUser();
            Organization = new Organization();
        }

        public Guid Id { get; set; }
        public Guid AdminId { get; set; }
        public Guid OrganizationId { get; set; }
        public virtual RegisteredUser Admin { get; set; }
        public virtual Organization Organization { get; set; }

    }
}
