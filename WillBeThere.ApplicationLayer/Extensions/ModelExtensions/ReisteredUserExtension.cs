﻿using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.DomainLayer.Extensions.ModelExtensions
{
    public static class ReisteredUserExtension
    {
        public static RegisteredUserDto ToDto(this RegisteredUser model)
        {
            return new RegisteredUserDto
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };
        }

        public static RegisteredUser ToModel(this RegisteredUserDto dto)
        {
            return new RegisteredUser
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
            };
        }
    }
}
