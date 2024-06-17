using WillBeThere.Shared.Dtos.ResultModels;
using WillBeThere.Shared.Extensions.ResultModels;
using WillBeThere.Shared.Models.ResultModels;

namespace WillBeThere.Shared.Assamblers.ResultModels
{
    public class PublicOrganizationProgramAssambler : Assambler<PublicOrganizationProgram, PublicOrganizationProgramDto>
    {
        public override PublicOrganizationProgramDto ToDto(PublicOrganizationProgram model)
        {
            return model.ToDto();
        }

        public override PublicOrganizationProgram ToModel(PublicOrganizationProgramDto dto)
        {
            return dto.ToModel();
        }
    }
}
