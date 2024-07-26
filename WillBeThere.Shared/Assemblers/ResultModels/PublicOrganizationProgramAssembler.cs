using WillBeThere.Shared.Dtos.ResultModels;
using WillBeThere.Shared.Extensions.ResultModels;
using WillBeThere.Shared.Models.ResultModels;

namespace WillBeThere.Shared.Assemblers.ResultModels
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
