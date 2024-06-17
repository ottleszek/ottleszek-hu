using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Extensions;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Assamblers
{
    public class PartipationAssambler : Assambler<Participation, ParticipationDto>
    {
        public override ParticipationDto ToDto(Participation model)
        {
            return model.ToDto();
        }

        public override Participation ToModel(ParticipationDto dto)
        {
            return dto.ToModel();
        }
    }
}
