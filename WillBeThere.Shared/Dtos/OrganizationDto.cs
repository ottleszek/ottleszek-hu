using WillBeThere.Shared.Models.DbIds;

namespace WillBeThere.Shared.Dtos
{
    public class OrganizationDto
    {
        public DbId Id { get; set; }= new DbId();
        public string Name { get; set; } =string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public DbId? OrganizationCategoryId { get; set; }
    }
}
