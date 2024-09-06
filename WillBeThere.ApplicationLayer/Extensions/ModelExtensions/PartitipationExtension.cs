using WillBeThere.ApplicationLayer.Dtos;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.DomainLayer.Extensions.ModelExtensions
{
    public static class PartitipationExtension
    {
        public static ParticipationDto ToDto(this Participation model)
        {
            return new ParticipationDto
            {
                Id = model.Id,
                OrganizationProgramId = model.OrganizationProgramId,
                RegisteredUserId = model.ParticipantId,
                Evaluation = model.Evaluation,
            };
        }

        public static Participation ToModel(this ParticipationDto dto)
        {
            return new Participation
            {
                Id = dto.Id,
                OrganizationProgramId = dto.OrganizationProgramId,
                ParticipantId = dto.RegisteredUserId,
            };
        }
    }
}
