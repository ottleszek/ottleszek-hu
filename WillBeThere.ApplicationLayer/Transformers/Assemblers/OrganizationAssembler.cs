using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.DomainLayer.Entites;
using Shared.ApplicationLayer.Transformers;
using WillBeThere.ApplicationLayer.Extensions.ModelExtensions;

namespace WillBeThere.ApplicationLayer.Transformers.Assemblers
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
