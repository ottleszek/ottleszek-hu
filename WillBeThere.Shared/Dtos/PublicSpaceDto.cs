using WillBeThere.Shared.Models.DbIds;

namespace WillBeThere.Shared.Dtos
{
    public class PublicSpaceDto
    {
        public DbId Id { get; set; } = new DbId();
        public string Name { get; set; } = string.Empty;
    }
}
