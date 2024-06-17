using System.Drawing;
using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Extensions;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Assamblers
{
    public class AddressAssambler : Assambler<Address, AddressDto>
    {
        public override AddressDto ToDto(Address model)
        {
            return model.ToDto();
        }

        public override Address ToModel(AddressDto dto)
        {
            return dto.ToModel();
        }
    }
}
