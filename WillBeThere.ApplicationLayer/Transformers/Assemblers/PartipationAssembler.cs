using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Extensions.ModelExtensions;
using SharedApplicationLayer.Transformers;

namespace WillBeThere.ApplicationLayer.Transformers.Assemblers
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
