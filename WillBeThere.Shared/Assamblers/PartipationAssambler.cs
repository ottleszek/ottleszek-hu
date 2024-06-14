using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Assamblers
{
    public class PartipationAssambler : Assambler<Participation, ParticipationDto>
    {
        public override ParticipationDto ToDto(Participation model)
        {
            return new ParticipationDto
            {
                Id = model.Id,
                OrganizationProgramId = model.OrganizationProgramId,
                RegisteredUserId = model.RegisteredUserId,
                Evaluation = model.Evaluation,
            };
        }

        public override Participation ToModel(ParticipationDto dto)
        {
            return new Participation
            {
                Id = dto.Id,
                OrganizationProgramId = dto.OrganizationProgramId,
                RegisteredUserId = dto.RegisteredUserId,
            };
        }
    }
}
