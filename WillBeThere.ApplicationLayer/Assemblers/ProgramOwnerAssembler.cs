using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Extensions.ModelExtensions;

namespace WillBeThere.ApplicationLayer.Assemblers
{
    public class ProgramOwnerAssembler : IAssembler<ProgramOwner, ProgramOwnerDto>
    {
        public ProgramOwnerDto ToDto(ProgramOwner model)
        {
            return model.ToDto();
        }

        public ProgramOwner ToModel(ProgramOwnerDto dto)
        {
            return dto.ToModel();
        }
    }
}
