using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Extensions.ModelExtensions
{
    public static class OrganizationCategoryExtension
    {
        public static OrganizationCategoryDto ToDto(this OrganizationCategory model)
        {
            return new OrganizationCategoryDto()
            {
                Id = model.Id,
                Name = model.Name,
            };
        }

        public static OrganizationCategory ToModel(this OrganizationCategoryDto dto)
        {
            return new OrganizationCategory
            {
                Id = dto.Id,
                Name = dto.Name,
            };
        }
    }
}
