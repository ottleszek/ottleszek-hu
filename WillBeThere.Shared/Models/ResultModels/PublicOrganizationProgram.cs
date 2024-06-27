using WillBeThere.Shared.Models.DbIds;

namespace WillBeThere.Shared.Models.ResultModels
{
    public class PublicOrganizationProgram 
    {
        public DbId Id { get; set; } = new DbId();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public DbId OrganizationId { get; set; } = new DbId();
        public string Organization { get; set; } = string.Empty ;
        public Address Address { get; set; } =new Address() ;
        public string PublicSpaceName { get; set; } = string.Empty ;

    }
}
