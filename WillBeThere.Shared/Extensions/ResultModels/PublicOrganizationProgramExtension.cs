using WillBeThere.Shared.Dtos.ResultModels;
using WillBeThere.Shared.Models;
using WillBeThere.Shared.Models.ResultModels;

namespace WillBeThere.Shared.Extensions.ResultModels
{
    public static class PublicOrganizationProgramExtension
    {
        public static PublicOrganizationProgramDto ToDto(this PublicOrganizationProgram model)
        {
            return new PublicOrganizationProgramDto
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Start = model.Start,
                End = model.End,
                Address = model.Address,
                Organization = model.Organization,
                OrganizationCategory = model.OrganizationCategory,
                OrganizationId = model.OrganizationId,
                PublicSpaceName = model.PublicSpaceName,

            };
        }

        public static PublicOrganizationProgram ToModel(this PublicOrganizationProgramDto dto)
        {
            return new PublicOrganizationProgram
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                Start = dto.Start,
                End = dto.End,
                Address = dto.Address,
                Organization = dto.Organization,
                OrganizationCategory = dto.OrganizationCategory,
                OrganizationId = dto.OrganizationId,
                PublicSpaceName = dto.PublicSpaceName,
            };
        }
    }
}
