using MediatR;
using Microsoft.AspNetCore.Mvc;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.ApplicationLayer.Contracts.Queries.OrganizationPrograms;
using WillBeThere.DomainLayer.Assemblers.ResultModels;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Entites.ResultModels;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos.Interfaces;

namespace WillBeThere.Backend.Controllers.WillBeThere
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationProgramController : IncludedController<OrganizationProgram, OrganizationProgramDto>
    {
        //private readonly IOrganizationProgramService? _organizationProgramService;
        private readonly IMediator? _mediator;
        private readonly PublicOrganizationProgramAssembler? _publicOrganizationProgramAssambler;
        private readonly IOrganizationProgramQueryRepo? _repo;

        public OrganizationProgramController(
            IMediator? mediator,
            OrganizationProgramAssembler? assambler, 
            PublicOrganizationProgramAssembler publicOrganizationProgramAssambler,
            IOrganizationProgramQueryRepo? repo
            //IOrganizationProgramService? organizationProgramService,
            
            ) : base(assambler, repo)
        {
            //_organizationProgramService = organizationProgramService;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _publicOrganizationProgramAssambler = publicOrganizationProgramAssambler;
            _repo = repo;
        }

        // GET: /api/OrganizationProgram/publicprograms
        [HttpGet("publicprograms")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OrganizationProgramDto>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetPublicPrograms()
        {
            List<PublicOrganizationProgram> pop = new List<PublicOrganizationProgram>();
            if (_mediator is not null && _publicOrganizationProgramAssambler is not null)
            {
                //IQueryable<PublicOrganizationProgram>? publicProgramsQuery = _organizationProgramService.GetPublicOrganizationsPrograms();
                List<PublicOrganizationProgram>? publicProgramsQuery = await _mediator.Send(new GetPublicOrgranizationProgramListQuery());
                if (publicProgramsQuery is not null)
                    return Ok(publicProgramsQuery.Select(pop =>_publicOrganizationProgramAssambler.ToDto(pop)));
            }
            return NoContent();
        }
    }
}
