using System.ComponentModel.DataAnnotations;
using WillBeThere.Domain.Entities.DbIds;

namespace WillBeThere.Domain.Entites
{
    public class PublicSpace : IDbEntity<PublicSpace>
    {
        public PublicSpace() 
        {
            Id=Guid.Empty;
            Name = string.Empty;
        }
        public PublicSpace(Guid id, string nameOfPublicSpace) 
        {
            Id=id;
            Name = nameOfPublicSpace;
        }
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; } = string.Empty;
        public virtual List<Address>? Addresses { get; set; }

    }
}
