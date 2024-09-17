using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Extensions.ModelExtensions;

namespace WillBeThere.ApplicationLayer.Assemblers
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
