using WillBeThere.Application.Dtos;
using WillBeThere.Domain.Entites;
using WillBeThere.Domain.Extensions.ModelExtensions;

namespace WillBeThere.Application.Assemblers
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
