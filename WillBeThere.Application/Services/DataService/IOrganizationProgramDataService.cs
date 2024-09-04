﻿using WillBeThere.Application.Assemblers;
using WillBeThere.Application.Dtos;
using WillBeThere.Domain.Entites;
using WillBeThere.Domain.Models.ResultModels;

namespace WillBeThere.Application.Services.DataService
{
    public interface IOrganizationProgramDataService : IBaseDataService<OrganizationProgram,OrganizationProgramDto,OrganizationProgramAssembler>
    {
        public Task<List<PublicOrganizationProgram>> GetAllPublicOrganizationProgramsAsync();
    }
}