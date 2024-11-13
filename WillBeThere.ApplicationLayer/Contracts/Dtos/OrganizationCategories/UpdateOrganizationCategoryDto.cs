namespace WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories
{
    public class UpdateOrganizationCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
