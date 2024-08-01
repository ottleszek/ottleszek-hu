using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Extensions.ModelExtensions
{
    public static class OrganizationAdminUserExtension
    {
        public static OrganizationAdminUserDto ToDto(this OrganizationAdminUser model)
        {
            return new OrganizationAdminUserDto
            {
                Id = model.Id,
                AdminId = model.AdminId,
                OrganizationId = model.OrganizationId,
            };
        }

        public static OrganizationAdminUser ToModel(this OrganizationAdminUserDto dto)
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
