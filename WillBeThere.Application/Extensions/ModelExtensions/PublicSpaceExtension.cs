using WillBeThere.Domain.Dtos;
using WillBeThere.Domain.Entites;

namespace WillBeThere.Domain.Extensions.ModelExtensions
{
    public static class PublicSpaceExtension
    {
        public static PublicSpaceDto ToDto(this PublicSpace model)
        {
            return new PublicSpaceDto
            {
                Id = model.Id,
                Name = model.Name,
            };
        }

        public static PublicSpace ToModel(this PublicSpaceDto dto)
        {
            return new PublicSpace
            {
                Id = dto.Id,
                Name = dto.Name,
            };
        }
    }
}
