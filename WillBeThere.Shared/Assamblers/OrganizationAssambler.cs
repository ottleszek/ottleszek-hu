using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Extensions;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Assamblers
{
    public class OrganizationAssambler : Assambler<Organization, OrganizationDto>
    {
        public override OrganizationDto ToDto(Organization model)
        {
            return model.ToDto();
        }

        public override Organization ToModel(OrganizationDto dto)
        {
            return dto.ToModel();
        }
    }
}
