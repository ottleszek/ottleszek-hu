using WillBeThere.Domain.Dtos;
using WillBeThere.Domain.Entites;
using WillBeThere.Domain.Extensions.ModelExtensions;

namespace WillBeThere.Application.Assemblers
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
