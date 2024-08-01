using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Extensions;
using WillBeThere.Shared.Extensions.ModelExtensions;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Assemblers
{
    public class AddressAssembler : IAssembler<Address, AddressDto>
    {
        public AddressDto ToDto(Address model)
        {
            return model.ToDto();
        }

        public  Address ToModel(AddressDto dto)
        {
            return dto.ToModel();
        }
    }
}
