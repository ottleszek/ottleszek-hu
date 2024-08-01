using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Extensions;
using WillBeThere.Shared.Extensions.ModelExtensions;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Assemblers
{
    public class PartipationAssembler : IAssembler<Participation, ParticipationDto>
    {
        public ParticipationDto ToDto(Participation model)
        {
            return model.ToDto();
        }

        public Participation ToModel(ParticipationDto dto)
        {
            return dto.ToModel();
        }
    }
}
