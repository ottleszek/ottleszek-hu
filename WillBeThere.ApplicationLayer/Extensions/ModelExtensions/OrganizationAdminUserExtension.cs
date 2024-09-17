using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.DomainLayer.Extensions.ModelExtensions
{
    public static class OrganizationAdminUserExtension
    {
        public static ProgramOwnerDto ToDto(this ProgramOwner model)
        {
            return new ProgramOwnerDto
            {
                Id = model.Id,
                //AdminId = model.EditorID,
                //OrganizationId = model.OrganizationId,
            };
        }

        public static ProgramOwner ToModel(this ProgramOwnerDto dto)
        {
            return new ProgramOwner
            {
                Id = dto.Id,
                //EditorID = dto.AdminId,
                //OrganizationId = dto.OrganizationId,
            };
        }
    }
}
