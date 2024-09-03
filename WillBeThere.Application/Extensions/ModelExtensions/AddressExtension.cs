﻿using WillBeThere.Domain.Dtos;
using WillBeThere.Domain.Entites;

namespace WillBeThere.Domain.Extensions.ModelExtensions
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
                PublicScapeID = model.PublicScapeId,
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
                PublicScapeId = dto.PublicScapeID,
            };
        }
    }
}