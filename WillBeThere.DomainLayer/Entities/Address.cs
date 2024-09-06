using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WillBeThere.DomainLayer.Entities.DbIds;


namespace WillBeThere.DomainLayer.Entites
{
    public class Address : IDbEntity<Address>
    {
        public Address() 
        {
            Id= Guid.Empty;
            Locality = string.Empty;
            PublicSpaceName = string.Empty;
            House = -1;
            Floor = -1;
            Door = -1;
            PostalCode = -1;
            PublicScapeId = new();
        }

        public Address(Guid id, Guid publicScapeID, string publicSpaceName, string locality, int house, int floor, int door, int postalCode) 
        {
            Id=id;
            PublicScapeId = publicScapeID;
            PublicSpaceName = publicSpaceName;
            Locality = locality;
            House = house;
            Floor = floor;
            Door = door;
            PostalCode = postalCode;
        }
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid PublicScapeId { get; set; }
        [Required]
        [StringLength(30)]
        public string PublicSpaceName { get; set; }
        [Required]
        [StringLength(30)]
        public string Locality { get; set; }
        public int House { get; set; }
        public int Floor { get; set; }
        public int Door { get; set; }
        public int PostalCode { get; set; }
        [ForeignKey(nameof(PublicScapeId))]
        public virtual PublicSpace? PublicSpace { get; set; }
        public virtual ICollection<OrganizationProgram>? OrganizationPrograms { get; set;}
    }
}
