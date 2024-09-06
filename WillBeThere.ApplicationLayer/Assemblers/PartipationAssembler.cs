using WillBeThere.ApplicationLayer.Dtos;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Extensions.ModelExtensions;

namespace WillBeThere.ApplicationLayer.Assemblers
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
