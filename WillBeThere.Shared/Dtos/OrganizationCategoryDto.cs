using WillBeThere.Shared.Models.DbIds;

namespace WillBeThere.Shared.Dtos
{
    public class OrganizationCategoryDto
    {
        public DbId Id { get; set; } = new DbId();
        public string Name { get; set; } = string.Empty;
    }
}
