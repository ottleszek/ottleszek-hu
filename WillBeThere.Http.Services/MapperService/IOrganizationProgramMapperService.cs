﻿using WillBeThere.Application.Assemblers;
using WillBeThere.Domain.Dtos;
using WillBeThere.Domain.Entites;
using WillBeThere.Domain.Models.ResultModels;

namespace WillBeThere.HttpService.MapperService
{
    public interface IOrganizationProgramMapperService : IBaseMapperService<OrganizationProgram, OrganizationProgramDto,OrganizationProgramAssembler>
    {
        Task<List<PublicOrganizationProgram>> GetAllPublicOrganizationProgramsAsync();
    }
}
