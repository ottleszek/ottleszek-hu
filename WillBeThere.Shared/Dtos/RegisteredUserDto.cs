using WillBeThere.Shared.Models.Guids;

namespace WillBeThere.Shared.Dtos
{
    public class RegisteredUserDto
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
