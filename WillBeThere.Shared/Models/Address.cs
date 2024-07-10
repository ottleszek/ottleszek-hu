using WillBeThere.Shared.Models.Guids;

namespace WillBeThere.Shared.Models
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

        public Guid Id { get; set; }
        public Guid PublicScapeId { get; set; }
        public string PublicSpaceName { get; set; }
        public string Locality { get; set; }
        public int House { get; set; }
        public int Floor { get; set; }
        public int Door { get; set; }
        public int PostalCode { get; set; }
        public virtual PublicSpace? PublicSpace { get; set; }
        public virtual List<OrganizationProgram>? OrganizationPrograms { get; set;}
    }
}
