using Shared.DomainLayer.Entities;

namespace WillBeThere.ApplicationLayer.Contracts.Dtos
{
    public class RegisteredUserDto : IDbEntity<RegisteredUserDto>
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
