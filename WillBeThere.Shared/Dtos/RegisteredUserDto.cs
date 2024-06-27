using WillBeThere.Shared.Models.DbIds;

namespace WillBeThere.Shared.Dtos
{
    public class RegisteredUserDto
    {
        public DbId Id { get; set; } = new DbId();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
