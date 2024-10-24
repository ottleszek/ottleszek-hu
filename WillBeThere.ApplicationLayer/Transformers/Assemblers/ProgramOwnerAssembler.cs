using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.DomainLayer.Entites;
using Shared.ApplicationLayer.Transformers;
using WWillBeThere.ApplicationLayer.Extensions.ModelExtensions;

namespace WillBeThere.ApplicationLayer.Transformers.Assemblers
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
