using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Extensions.ModelExtensions;

namespace WillBeThere.ApplicationLayer.Assemblers
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
