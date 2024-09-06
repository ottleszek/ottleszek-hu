using WillBeThere.ApplicationLayer.Dtos;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Extensions.ModelExtensions;

namespace WillBeThere.ApplicationLayer.Assemblers
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
