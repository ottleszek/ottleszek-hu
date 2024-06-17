using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Extensions;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Assamblers
{
    public class PublicSpaceAssambler : Assambler<PublicSpace, PublicSpaceDto>
    {
        public override PublicSpaceDto ToDto(PublicSpace model)
        {
            return model.ToDto();
        }

        public override PublicSpace ToModel(PublicSpaceDto dto)
        {
            return dto.ToModel();
        }
    }
}
