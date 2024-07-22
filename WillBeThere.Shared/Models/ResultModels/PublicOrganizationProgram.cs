namespace WillBeThere.Shared.Models.ResultModels
{
    public class PublicOrganizationProgram 
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public Guid OrganizationId { get; set; } = Guid.NewGuid();
        public string Organization { get; set; } = string.Empty ;
        public Address Address { get; set; } =new Address() ;
        public string PublicSpaceName { get; set; } = string.Empty ;


        public string GetHungarianAddress()
        {
            string addressNumber = $"{Address.House}.";
            if (Address.Floor > 0)
                addressNumber = $"{Address.House}/{Address.Floor}";
            else if (Address.Floor > 0 && Address.Door > 0)
                addressNumber = $"{Address.House}/{Address.Floor}/{Address.Door}";

            return $"{Address.Locality}\n{Address.PublicSpaceName} {PublicSpaceName} {addressNumber} \n{Address.PostalCode} ";
        }

    }
}
