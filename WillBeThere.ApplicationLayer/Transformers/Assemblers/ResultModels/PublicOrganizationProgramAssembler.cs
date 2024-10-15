using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.Dtos.ResultModels;
using WillBeThere.ApplicationLayer.Extensions.ModelExtensions;
using WillBeThere.DomainLayer.Entites.ResultModels;
using SharedApplicationLayer.Transformers;

namespace WillBeThere.ApplicationLayer.Transformers.Assemblers.ResultModels
{
    public class PublicOrganizationProgramAssembler : IAssembler<PublicOrganizationProgram, PublicOrganizationProgramDto>
    {
        public PublicOrganizationProgramDto ToDto(PublicOrganizationProgram model)
        {
            return model.ToDto();
        }

        public PublicOrganizationProgram ToModel(PublicOrganizationProgramDto dto)
        {
            return dto.ToModel();
        }
    }
}
