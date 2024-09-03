using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Extensions;
using WillBeThere.Shared.Extensions.ModelExtensions;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Assemblers
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
