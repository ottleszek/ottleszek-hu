namespace WillBeThere.Shared.Dtos
{
    public class RegisteredUserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
