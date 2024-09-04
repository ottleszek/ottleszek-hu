
using WillBeThere.Application.Dtos.ResultModels;
using WillBeThere.Domain.Models.ResultModels;

namespace WillBeThere.Application.Extensions.ModelExtensions
{
    public static class PublicOrganizationProgramExtension
    {
        public static PublicOrganizationProgramDto ToDto(this PublicOrganizationProgram publicOrganizationProgram)
        {
            return new PublicOrganizationProgramDto
            {
                Id = publicOrganizationProgram.Id,
                Title = publicOrganizationProgram.Title,
                Address = publicOrganizationProgram.Address,
                Description = publicOrganizationProgram.Description,
                Start = publicOrganizationProgram.Start,
                End = publicOrganizationProgram.End,      
                OrganizationId = publicOrganizationProgram.OrganizationId,
                Organization=publicOrganizationProgram.Organization,
                OrganizationCategory = publicOrganizationProgram.OrganizationCategory,
                PublicSpaceName = publicOrganizationProgram.PublicSpaceName,
            };
        }

        public static PublicOrganizationProgram ToModel(this PublicOrganizationProgramDto publicOrganizationProgramDto)
        {
            {
                return new PublicOrganizationProgram
                {
                    Id = publicOrganizationProgramDto.Id,
                    Title = publicOrganizationProgramDto.Title,
                    Address = publicOrganizationProgramDto.Address,
                    Description = publicOrganizationProgramDto.Description,
                    Start = publicOrganizationProgramDto.Start,
                    End = publicOrganizationProgramDto.End,
                    OrganizationId = publicOrganizationProgramDto.OrganizationId,
                    Organization = publicOrganizationProgramDto.Organization,
                    OrganizationCategory = publicOrganizationProgramDto.OrganizationCategory,
                    PublicSpaceName = publicOrganizationProgramDto.PublicSpaceName,
                };
            }
        }
    }
}
