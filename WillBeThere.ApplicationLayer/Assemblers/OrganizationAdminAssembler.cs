using WillBeThere.ApplicationLayer.Dtos;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Extensions.ModelExtensions;

namespace WillBeThere.ApplicationLayer.Assemblers
{
    public class OrganizationAdminAssembler : IAssembler<ProgramOwner, OrganizationAdminUserDto>
    {
        public OrganizationAdminUserDto ToDto(ProgramOwner model)
        {
            return model.ToDto();
        }

        public ProgramOwner ToModel(OrganizationAdminUserDto dto)
        {
            return dto.ToModel();
        }
    }
}
