using WillBeThere.Shared.Models.DbIds;

namespace WillBeThere.Shared.Dtos
{
    public class OrganizationAdminUserDto
    {
        public DbId Id { get; set; } = new DbId();
        public DbId AdminId { get; set; } = new DbId();
        public DbId OrganizationId { get; set; } = new DbId();
    }
}
