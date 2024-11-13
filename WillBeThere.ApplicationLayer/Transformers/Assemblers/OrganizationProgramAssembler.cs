using Shared.ApplicationLayer.Transformers;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.ApplicationLayer.Extensions.ModelExtensions;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Transformers.Assemblers
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
