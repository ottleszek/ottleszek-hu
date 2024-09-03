using WillBeThere.Domain.Dtos;
using WillBeThere.Domain.Entites;
using WillBeThere.Domain.Extensions.ModelExtensions;

namespace WillBeThere.Application.Assemblers
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
