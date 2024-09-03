using WillBeThere.Domain.Dtos;
using WillBeThere.Domain.Entites;
using WillBeThere.Domain.Extensions.ModelExtensions;

namespace WillBeThere.Application.Assemblers
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
