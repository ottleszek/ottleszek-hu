using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Extensions.ModelExtensions;
using SharedApplicationLayer.Assamblers;

namespace WillBeThere.ApplicationLayer.Assemblers
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
