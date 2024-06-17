using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Extensions;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Assamblers
{
    public class OrganizationAdminAssambler : Assambler<OrganizationAdminUser, OrganizationAdminUserDto>
    {
        public override OrganizationAdminUserDto ToDto(OrganizationAdminUser model)
        {
            return model.ToDto();
        }

        public override OrganizationAdminUser ToModel(OrganizationAdminUserDto dto)
        {
            return dto.ToModel();
        }
    }
}
