using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WillBeThere.Shared.Models.Guids;

namespace WillBeThere.Shared.Models
{
    public class OrganizationAdminUser : IDbEntity<OrganizationAdminUser>
    {
        public OrganizationAdminUser() 
        {
            Id = Guid.Empty;
            AdminId = new();
            OrganizationId = new();
        }

        public OrganizationAdminUser(Guid id, Guid adminId, Guid organizationId) 
        {
            Id = id;
            AdminId = adminId;
            OrganizationId = organizationId;
        }
        public Guid Id { get; set; }
        public Guid AdminId { get; set; }
        public Guid OrganizationId { get; set; }
        public virtual RegisteredUser? Admin { get; set; }
        public virtual Organization? Organization { get; set; }
        // 1:N OrganizationAdminUser (ProgramOwner) - OrganizationProgram
        public virtual List<OrganizationProgram>? OrganizationPrograms { get; set; }

    }
}
