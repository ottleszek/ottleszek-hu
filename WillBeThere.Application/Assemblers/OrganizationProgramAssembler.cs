using WillBeThere.Application.Dtos;
using WillBeThere.Domain.Entites;
using WillBeThere.Domain.Extensions.ModelExtensions;

namespace WillBeThere.Application.Assemblers
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
