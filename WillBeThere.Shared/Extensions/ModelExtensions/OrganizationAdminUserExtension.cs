using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Extensions.ModelExtensions
{
    public static class OrganizationAdminUserExtension
    {
        public static OrganizationAdminUserDto ToDto(this ProgramOwner model)
        {
            return new OrganizationAdminUserDto
            {
                Id = model.Id,
                AdminId = model.EditorID,
                OrganizationId = model.OrganizationId,
            };
        }

        public static ProgramOwner ToModel(this OrganizationAdminUserDto dto)
        {
            return new ProgramOwner
            {
                Id = dto.Id,
                EditorID = dto.AdminId,
                OrganizationId = dto.OrganizationId,
            };
        }
    }
}
