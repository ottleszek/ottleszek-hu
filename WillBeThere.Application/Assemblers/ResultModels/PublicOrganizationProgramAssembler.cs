using WillBeThere.Application.Assemblers;
using WillBeThere.Application.Extensions.ModelExtensions;
using WillBeThere.Domain.Dtos.ResultModels;
using WillBeThere.Domain.Models.ResultModels;

namespace WillBeThere.Domain.Assemblers.ResultModels
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
