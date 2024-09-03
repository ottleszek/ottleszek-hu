using WillBeThere.Application.Dtos;
using WillBeThere.Domain.Entites;
using WillBeThere.Domain.Extensions.ModelExtensions;

namespace WillBeThere.Application.Assemblers
{
    public class OrganizationAssembler : IAssembler<Organization, OrganizationDto>
    {
        public OrganizationDto ToDto(Organization model)
        {
            return model.ToDto();
        }

        public Organization ToModel(OrganizationDto dto)
        {
            return dto.ToModel();
        }
    }
}
