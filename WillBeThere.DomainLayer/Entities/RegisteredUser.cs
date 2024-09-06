using System.ComponentModel.DataAnnotations;
using WillBeThere.DomainLayer.Entities.DbIds;

namespace WillBeThere.DomainLayer.Entites
{
    public class RegisteredUser : IDbEntity<RegisteredUser>
    {
        public RegisteredUser() 
        {
            Id=Guid.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;

        }

        public RegisteredUser(Guid id, string firstName, string lastName) 
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        [Key]
        [Required]
        public Guid Id { get ; set; }
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string LastName { get; set; }        

        // N:M RegisteredUser - Participation - Organization program
        public virtual ICollection<Participation>? Paticipations { get; set; }
        // 1:1 RegisteredUser - Editor
        public virtual Editor? Editor { get; set; }
        public string HungrianName => $"{LastName} {FirstName}";


    }
}
