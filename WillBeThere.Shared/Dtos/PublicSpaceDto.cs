using WillBeThere.Shared.Models.Guids;

namespace WillBeThere.Shared.Dtos
{
    public class PublicSpaceDto
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
