﻿using WillBeThere.HttpService.HttpService;
using WillBeThere.Shared.Assemblers;
using WillBeThere.Shared.Assemblers.ResultModels;
using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Dtos.ResultModels;
using WillBeThere.Shared.Models;
using WillBeThere.Shared.Models.ResultModels;

namespace WillBeThere.HttpService.MapperService
{
    public class OrganizationProgramMapperService : BaseMapperService<OrganizationProgram, OrganizationProgramDto, OrganizationProgramAssembler>, IOrganizationProgramMapperService
    {
        private readonly IOrganizationProgramHttpService? _organizationProgramHttpService;
        private readonly PublicOrganizationProgramAssembler? _publicOrganizationProgramAssembler;

        public OrganizationProgramMapperService(
            IOrganizationProgramHttpService?organizationProgramHttpService, 
            OrganizationProgramAssembler? assambler,
            PublicOrganizationProgramAssembler? publicOrganizationProgramAssembler) : 
            base(organizationProgramHttpService, assambler)
        {
            if (organizationProgramHttpService is not null && publicOrganizationProgramAssembler is not null)
            {
                _organizationProgramHttpService = organizationProgramHttpService;
                _publicOrganizationProgramAssembler = publicOrganizationProgramAssembler;
            }
        }

        public async Task<List<PublicOrganizationProgram>> GetAllPublicOrganizationProgramsAsync()
        {
            if (_organizationProgramHttpService is null || _publicOrganizationProgramAssembler is null)
                return new List<PublicOrganizationProgram>();
            else
            {
                List<PublicOrganizationProgramDto> resultDto = await _organizationProgramHttpService.GetAllPublicOrganizationProgramsAsync();
                return resultDto.Select(entityDto => _publicOrganizationProgramAssembler.ToModel(entityDto)).ToList();
            }
        }
    }
}
