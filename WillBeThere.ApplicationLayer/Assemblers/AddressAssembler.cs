using WillBeThere.ApplicationLayer.Dtos;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Extensions.ModelExtensions;

namespace WillBeThere.ApplicationLayer.Assemblers
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
