using MediatR;
using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore;
using WillBeThere.Application.Assemblers;
using WillBeThere.Application.Dtos;
using WillBeThere.Application.Queries.OrganizationPrograms;
using WillBeThere.Domain.Assemblers.ResultModels;
using WillBeThere.Domain.Entites;
using WillBeThere.Domain.Models.ResultModels;
using WillBeThere.Infrastucture.Implementations.Repos.WillBeThere;
using WillBeThere.Infrastucture.Implementations.Services;

namespace WillBeThere.Backend.Controllers.WillBeThere
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationProgramController : IncludedController<OrganizationProgram, OrganizationProgramDto>
    {
        //private readonly IOrganizationProgramService? _organizationProgramService;
        private readonly IMediator _mediator;
        private readonly PublicOrganizationProgramAssembler _publicOrganizationProgramAssambler;
        private readonly IOrganizationProgramRepo? repo;

        public OrganizationProgramController(
            OrganizationProgramAssembler? assambler, 
            PublicOrganizationProgramAssembler publicOrganizationProgramAssambler,
            IOrganizationProgramRepo? repo,
            //IOrganizationProgramService? organizationProgramService,
            IMediator mediator
            ) : base(assambler, repo)
        {
            //_organizationProgramService = organizationProgramService;
            _mediator = mediator;
            _publicOrganizationProgramAssambler = publicOrganizationProgramAssambler;
            this.repo = repo;
        }

        // GET: /api/OrganizationProgram/publicprograms
        [HttpGet("publicprograms")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OrganizationProgramDto>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetPublicPrograms()
        {
            List<PublicOrganizationProgram> pop = new List<PublicOrganizationProgram>();
            if (_mediator is not null)
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
