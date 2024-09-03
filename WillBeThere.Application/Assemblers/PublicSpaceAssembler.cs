using WillBeThere.Application.Dtos;
using WillBeThere.Domain.Entites;
using WillBeThere.Domain.Extensions.ModelExtensions;


namespace WillBeThere.Application.Assemblers
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
