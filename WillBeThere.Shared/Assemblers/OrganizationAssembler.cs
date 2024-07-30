using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Extensions;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Assemblers
{
    public class OrganizationAssembler : IAssembler<Organization, OrganizationDto>
    {
        public OrganizationDto ToDto(Organization model)
        {
            return model.ToDto();
        }

        public Organization ToModel(OrganizationDto dto)
        {
            return dto.ToModel();
        }
    }
}
