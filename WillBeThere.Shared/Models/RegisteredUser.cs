using WillBeThere.Shared.Models.DbIds;

namespace WillBeThere.Shared.Models
{
    public class RegisteredUser : IDbEntity<RegisteredUser>
    {
        public RegisteredUser() 
        {
            Id=new DbId();
            FirstName = string.Empty;
            LastName = string.Empty;

        }

        public RegisteredUser(DbId id, string firstName, string lastName) 
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public DbId Id { get ; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Participation>? RegisteredUserPaticipations { get; set; }
        public virtual OrganizationAdminUser? OrganizationAdminUser { get; set; }
        public string HungrianName => $"{LastName} {FirstName}";

    }
}
