using WillBeThere.Shared.Dtos.ResultModels;
using WillBeThere.Shared.Models.ResultModels;

namespace WillBeThere.Shared.Assamblers.ResultModels
{
    public class PublicOrganizationProgramAssambler : Assambler<PublicOrganizationProgram, PublicOrganizationProgramDto>
    {
        public override PublicOrganizationProgramDto ToDto(PublicOrganizationProgram model)
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
                OrganizationId = model.OrganizationId,
            };
        }

        public override PublicOrganizationProgram ToModel(PublicOrganizationProgramDto dto)
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
                OrganizationId = dto.OrganizationId,
            };
        }
    }
}
