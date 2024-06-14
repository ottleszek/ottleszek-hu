using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Assamblers
{
    public class PublicSpaceAssambler : Assambler<PublicSpace, PublicSpaceDto>
    {
        public override PublicSpaceDto ToDto(PublicSpace model)
        {
            return new PublicSpaceDto
            {
                Id = model.Id,
                Name = model.Name,
            };
        }

        public override PublicSpace ToModel(PublicSpaceDto dto)
        {
            return new PublicSpace
            {
                Id = dto.Id,
                Name = dto.Name,
            };
        }
    }
}
