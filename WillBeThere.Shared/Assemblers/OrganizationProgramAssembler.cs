using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Extensions;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Assemblers
{
    public class OrganizationProgramAssembler : IAssembler<OrganizationProgram, OrganizationProgramDto>
    {
        public OrganizationProgramDto ToDto(OrganizationProgram model)
        {
            return model.ToDto();
        }

        public OrganizationProgram ToModel(OrganizationProgramDto dto)
        {
            return dto.ToModel();
        }
    }
}
