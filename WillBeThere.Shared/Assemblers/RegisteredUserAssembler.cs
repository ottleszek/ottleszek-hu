using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Extensions.ModelExtensions;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Assemblers
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
