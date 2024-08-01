using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Extensions;
using WillBeThere.Shared.Extensions.ModelExtensions;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Assemblers
{
    public class PublicSpaceAssembler : IAssembler<PublicSpace, PublicSpaceDto>
    {
        public PublicSpaceDto ToDto(PublicSpace model)
        {
            return model.ToDto();
        }

        public PublicSpace ToModel(PublicSpaceDto dto)
        {
            return dto.ToModel();
        }
    }
}
