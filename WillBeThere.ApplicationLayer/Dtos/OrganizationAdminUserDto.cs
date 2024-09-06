namespace WillBeThere.ApplicationLayer.Dtos
{
    public class OrganizationAdminUserDto
    {
        public Guid Id { get; set; } = Guid.Empty;
        public Guid AdminId { get; set; } = Guid.Empty;
        public Guid OrganizationId { get; set; } = Guid.Empty;
    }
}
