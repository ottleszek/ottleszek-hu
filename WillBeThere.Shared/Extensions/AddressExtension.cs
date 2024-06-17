using System.Reflection;
using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Extensions
{
    public static class AddressExtension
    {
        public static AddressDto ToDto(this Address model)
        {
            return new AddressDto
            {
                Id = model.Id,
                Locality = model.Locality,
                PublicSpaceName = model.PublicSpaceName,
                House = model.House,
                Floor = model.Floor,
                Door = model.Door,
                PostalCode = model.PostalCode,
                PublicScapeID = model.PublicScapeID,
            };
        }

        public static Address ToModel(this AddressDto dto)
        {
            return new Address
            {
                Id = dto.Id,
                Locality = dto.Locality,
                PublicSpaceName = dto.PublicSpaceName,
                House = dto.House,
                Floor = dto.Floor,
                Door = dto.Door,
                PostalCode = dto.PostalCode,
                PublicScapeID = dto.PublicScapeID,
            };
        }
    }
}
