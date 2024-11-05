﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.ApplicationLayer.Repos.UnitOfWork;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.ApplicationLayer.Contracts.Dtos.ResultModels;
using WillBeThere.ApplicationLayer.Queries.OrganizationPrograms;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.WillBeThere;
using WillBeThere.ApplicationLayer.Transformers.Assemblers;
using WillBeThere.ApplicationLayer.Transformers.Assemblers.ResultModels;
using WillBeThere.Backend.Controllers.Base;
using WillBeThere.DomainLayer.Entites;


namespace WillBeThere.Backend.Controllers.WillBeThere
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationProgramController : IncludedController<OrganizationProgram, OrganizationProgramDto>
    {
        //private readonly IOrganizationProgramService? _organizationProgramService;
        private readonly IMediator? _mediator;
        private readonly PublicOrganizationProgramAssembler? _publicOrganizationProgramAssambler;

        public OrganizationProgramController(
            IMediator? mediator,
            OrganizationProgramAssembler? assambler, 
            PublicOrganizationProgramAssembler publicOrganizationProgramAssambler,
            IOrganizationProgramQueryRepo? queryRepo,
            IOrganizationProgramCommandRepo? commandRepo,
            IUnitOfWork unitOfWork
            //IOrganizationProgramService? organizationProgramService,
            
            ) : base(assambler, queryRepo)
        {
            //_organizationProgramService = organizationProgramService;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _publicOrganizationProgramAssambler = publicOrganizationProgramAssambler;
        }

        // GET: /api/OrganizationProgram/publicprograms
        [HttpGet("publicprograms")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OrganizationProgramDto>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetPublicPrograms()
        {
            if (_mediator is not null && _publicOrganizationProgramAssambler is not null)
            {
                List<PublicOrganizationProgramDto> pop = await _mediator.Send(new GetPublicOrgranizationProgramListQuery());
                return Ok(pop);
            }
            return NoContent();
        }
    }
}
