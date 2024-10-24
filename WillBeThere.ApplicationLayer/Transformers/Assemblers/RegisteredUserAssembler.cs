using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.DomainLayer.Entites;
using Shared.ApplicationLayer.Transformers;
using WillBeThere.ApplicationLayer.Extensions.ModelExtensions;

namespace WillBeThere.ApplicationLayer.Transformers.Assemblers
{
    public class RegisteredUserAssembler : IAssembler<RegisteredUser, RegisteredUserDto>
    {
        public RegisteredUserDto ToDto(RegisteredUser model)
        {
            return model.ToDto();
        }

        public RegisteredUser ToModel(RegisteredUserDto dto)
        {
            return dto.ToModel();
        }
    }
}
