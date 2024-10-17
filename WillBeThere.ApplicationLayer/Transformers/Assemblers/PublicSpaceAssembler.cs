using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.DomainLayer.Entites;
using SharedApplicationLayer.Transformers;
using WillBeThere.ApplicationLayer.Extensions.ModelExtensions;

namespace WillBeThere.ApplicationLayer.Transformers.Assemblers
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
