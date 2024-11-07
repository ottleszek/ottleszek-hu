﻿using WillBeThere.DomainLayer.Entites;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using Shared.InfrastuctureLayer.Repos.ModelRepo;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.ModelRepo;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.MapperRepo;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.Http.ModelRepo.Query
{
    public class OrganizationProgramQueryModelRepo : QueryModelRepo<OrganizationProgram, OrganizationProgramDto>, IOrganizationProgramQueryModelRepo
    {
        public OrganizationProgramQueryModelRepo(IOrganizationProgramQueryMapperRepo? mapperRepo) : base(mapperRepo)
        {
        }
    }
}