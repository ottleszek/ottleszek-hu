﻿using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Extensions
{
    public static class PartitipationExtension
    {
        public static ParticipationDto ToDto(this Participation model)
        {
            return new ParticipationDto
            {
                Id = model.Id,
                OrganizationProgramId = model.OrganizationProgramId,
                RegisteredUserId = model.RegisteredUserId,
                Evaluation = model.Evaluation,
            };
        }

        public static Participation ToModel(this ParticipationDto dto)
        {
            return new Participation
            {
                Id = dto.Id,
                OrganizationProgramId = dto.OrganizationProgramId,
                RegisteredUserId = dto.RegisteredUserId,
            };
        }
    }
}
