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
            };
        }

        public override PublicOrganizationProgram ToModel(PublicOrganizationProgramDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
