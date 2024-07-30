using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Extensions;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Assemblers
{
    public class OrganizationAdminAssembler : IAssembler<OrganizationAdminUser, OrganizationAdminUserDto>
    {
        public OrganizationAdminUserDto ToDto(OrganizationAdminUser model)
        {
            return model.ToDto();
        }

        public OrganizationAdminUser ToModel(OrganizationAdminUserDto dto)
        {
            return dto.ToModel();
        }
    }
}
