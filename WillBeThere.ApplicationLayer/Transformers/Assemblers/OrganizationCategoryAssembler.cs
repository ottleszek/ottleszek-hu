using WillBeThere.DomainLayer.Entites;
using Shared.ApplicationLayer.Transformers;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.ApplicationLayer.Extensions.ModelExtensions;

namespace WillBeThere.ApplicationLayer.Transformers.Assemblers
{
    public class OrganizationCategoryAssembler : IAssembler<OrganizationCategory, OrganizationCategoryDto>
    {
        public OrganizationCategoryDto ToDto(OrganizationCategory model)
        {
            return model.ToDto();
        }

        public OrganizationCategory ToModel(OrganizationCategoryDto dto)
        {
            return dto.ToModel();
        }
    }
}
