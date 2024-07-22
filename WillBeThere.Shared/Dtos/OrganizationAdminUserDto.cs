using WillBeThere.Shared.Models.Guids;

namespace WillBeThere.Shared.Dtos
{
    public class OrganizationAdminUserDto
    {
        public Guid Id { get; set; } = Guid.Empty;
        public Guid AdminId { get; set; } = Guid.Empty;
        public Guid OrganizationId { get; set; } = Guid.Empty;
    }
}
