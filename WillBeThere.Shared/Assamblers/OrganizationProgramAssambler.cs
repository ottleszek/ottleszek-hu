using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Extensions;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Assamblers
{
    public class OrganizationProgramAssambler : Assambler<OrganizationProgram, OrganizationProgramDto>
    {
        public override OrganizationProgramDto ToDto(OrganizationProgram model)
        {
            return model.ToDto();
        }

        public override OrganizationProgram ToModel(OrganizationProgramDto dto)
        {
            return dto.ToModel();
        }
    }
}
