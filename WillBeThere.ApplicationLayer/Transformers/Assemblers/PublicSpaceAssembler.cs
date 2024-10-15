using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Extensions.ModelExtensions;
using SharedApplicationLayer.Transformers;

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
