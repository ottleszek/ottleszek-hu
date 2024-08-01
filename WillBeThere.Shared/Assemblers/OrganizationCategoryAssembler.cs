using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Extensions;
using WillBeThere.Shared.Extensions.ModelExtensions;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Assemblers
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
