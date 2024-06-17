using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Extensions;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Assamblers
{
    public class RegisteredUserAssambler : Assambler<RegisteredUser, RegisteredUserDto>
    {
        public override RegisteredUserDto ToDto(RegisteredUser model)
        {
            return model.ToDto();
        }

        public override RegisteredUser ToModel(RegisteredUserDto dto)
        {
            return dto.ToModel();
        }
    }
}
