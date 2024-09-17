using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Contracts.Dtos.ResultModels
{
    public class PublicOrganizationProgramDto
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public Guid OrganizationId { get; set; } = Guid.Empty;
        public string Organization { get; set; } = string.Empty;
        public string OrganizationCategory { get; set; } = string.Empty;
        public Address Address { get; set; } = new Address();
        public string PublicSpaceName { get; set; } = string.Empty;
    }
}
