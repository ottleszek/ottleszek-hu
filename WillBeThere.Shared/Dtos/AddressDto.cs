namespace WillBeThere.Shared.Dtos
{
    public class AddressDto
    {
        public Guid Id { get; set; }
        public Guid? PublicScapeID { get; set; }
        public string PublicSpaceName { get; set; } = string.Empty;
        public string Locality { get; set; }= string.Empty;
        public int House { get; set; }
        public int Floor { get; set; }
        public int Door { get; set; }
        public int PostalCode { get; set; } = 0;
    }
}
