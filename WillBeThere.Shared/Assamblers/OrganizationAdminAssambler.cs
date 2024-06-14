using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Assamblers
{
    public class OrganizationAdminAssambler : Assambler<OrganizationAdminUser, OrganizationAdminUserDto>
    {
        public override OrganizationAdminUserDto ToDto(OrganizationAdminUser model)
        {
            return new OrganizationAdminUserDto
            {
                Id = model.Id,
                AdminId = model.AdminId,
                OrganizationId = model.OrganizationId,
            };
        }

        public override OrganizationAdminUser ToModel(OrganizationAdminUserDto dto)
        {
            return new OrganizationAdminUser
            {
                Id = dto.Id,
                AdminId = dto.AdminId,
                OrganizationId = dto.OrganizationId,
            };
        }
    }
}
