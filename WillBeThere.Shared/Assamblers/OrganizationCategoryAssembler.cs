using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Assamblers
{
    public class OrganizationCategoryAssembler : Assambler<OrganizationCategory, OrganizationCategoryDto>
    {
        public override OrganizationCategoryDto ToDto(OrganizationCategory model)
        {
            return new OrganizationCategoryDto()
            {
                Id = model.Id,
                Name = model.Name,
            };
        }

        public override OrganizationCategory ToModel(OrganizationCategoryDto dto)
        {
            return new OrganizationCategory
            {
                Id = dto.Id,
                Name = dto.Name,
            };
        }
    }
}
