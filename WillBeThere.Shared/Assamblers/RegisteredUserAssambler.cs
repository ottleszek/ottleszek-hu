using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Assamblers
{
    public class RegisteredUserAssambler : Assambler<RegisteredUser, RegisteredUserDto>
    {
        public override RegisteredUserDto ToDto(RegisteredUser model)
        {
            return new RegisteredUserDto
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };
        }

        public override RegisteredUser ToModel(RegisteredUserDto dto)
        {
            return new RegisteredUser
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
            };
        }
    }
}
