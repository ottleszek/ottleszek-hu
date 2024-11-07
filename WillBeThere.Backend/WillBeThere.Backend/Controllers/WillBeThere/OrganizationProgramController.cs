using MediatR;
using Microsoft.AspNetCore.Mvc;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.ApplicationLayer.Contracts.Dtos.ResultModels;
using WillBeThere.ApplicationLayer.Queries.OrganizationPrograms;
using WillBeThere.ApplicationLayer.Repos.QueryRepo;
using WillBeThere.ApplicationLayer.Transformers.Assemblers;
using WillBeThere.Backend.Controllers.Base;
using WillBeThere.DomainLayer.Entites;


namespace WillBeThere.Backend.Controllers.WillBeThere
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationProgramController : IncludedController<OrganizationProgram, OrganizationProgramDto>
    {
        private readonly IMediator? _mediator;
        
        public OrganizationProgramController(
            IMediator? mediator,
            OrganizationProgramAssembler? assambler, 
            IOrganizationProgramQueryRepo? queryRepo
            
            ) : base(assambler, queryRepo)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // GET: /api/OrganizationProgram/publicprograms
        [HttpGet("publicprograms")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OrganizationProgramDto>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetPublicPrograms()
        {
            if (_mediator is not null)
            {
                List<PublicOrganizationProgramDto> pop = await _mediator.Send(new GetPublicOrgranizationProgramListQuery());
                return Ok(pop);
            }
            return NoContent();
        }
    }
}
