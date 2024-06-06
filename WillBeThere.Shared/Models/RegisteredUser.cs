
namespace WillBeThere.Shared.Models
{
    public class RegisteredUser : IDbEntity<RegisteredUser>
    {
        public RegisteredUser()
        {
            Id = Guid.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;

        }

        public RegisteredUser(Guid id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<OrganizationProgram>? OrganizationPrograms { get; set; }
        public virtual ICollection<Participation>? RegisteredUserPaticipations { get; set; }
        public virtual OrganizationAdminUser? OrganizationAdminUser { get; set; }
        public string HungrianName => $"{LastName} {FirstName}";
    }
}
