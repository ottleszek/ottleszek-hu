using SharedApplicationLayer.Transformers;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.ApplicationLayer.Extensions.ModelExtensions;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Transformers.Assemblers
{
    public class AddressAssembler : IAssembler<Address, AddressDto>
    {
        public AddressDto ToDto(Address model)
        {
            return model.ToDto();
        }

        public Address ToModel(AddressDto dto)
        {
            return dto.ToModel();
        }
    }
}
