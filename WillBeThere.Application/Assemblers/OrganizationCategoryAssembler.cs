using WillBeThere.Application.Dtos;
using WillBeThere.Domain.Entites;
using WillBeThere.Domain.Extensions.ModelExtensions;

namespace WillBeThere.Application.Assemblers
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
