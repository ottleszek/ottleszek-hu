
namespace WillBeThere.Domain.Dtos
{
    public class AddressDto
    {
        public Guid Id { get; set; } = Guid.Empty;
        public Guid PublicScapeID { get; set; } = Guid.Empty;
        public string PublicSpaceName { get; set; } = string.Empty;
        public string Locality { get; set; }= string.Empty;
        public int House { get; set; }
        public int Floor { get; set; }
        public int Door { get; set; }
        public int PostalCode { get; set; } = 0;
    }
}
