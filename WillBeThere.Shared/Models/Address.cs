namespace WillBeThere.Shared.Models
{     public class Address : IDbEntity<Address>
    {
        public Address()
        {
            Id = Guid.Empty;
            Locality = string.Empty;
            PublicSpaceName = string.Empty;
            House = -1;
            Floor = -1;
            Door = -1;
            PostalCode = -1;
            PublicScapeID = Guid.Empty;
        }
        public Address(Guid id, string locality, string publicSpaceName, int house, int floor, int door, int postalCode, Guid publicScapeID)
        {
            Id = id;
            Locality = locality;
            PublicSpaceName = publicSpaceName;
            House = house;
            Floor = floor;
            Door = door;
            PostalCode = postalCode;
            PublicScapeID = publicScapeID;
        }

        public Guid Id { get; set; }
        public Guid? PublicScapeID { get; set; }
        public virtual PublicSpace? PublicSpace { get; set; }
        public string PublicSpaceName { get; set; }
        public string Locality { get; set; }
        public int House { get; set; }
        public int Floor { get; set; }
        public int Door { get; set; }
        public int PostalCode { get; set; }
        public bool HasId => Id !=Guid.Empty;
        public virtual List<OrganizationProgram>? OrganizationPrograms { get; set;}
    }
}
