using SharedDomainLayer.Entities;

namespace WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories
{
    public class OrganizationCategoryDto : IDbEntity<OrganizationCategoryDto>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
