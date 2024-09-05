using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore;
using WillBeThere.Application.Assemblers;
using WillBeThere.Application.Dtos;
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
        private readonly IOrganizationProgramService? _organizationProgramService;
        private readonly PublicOrganizationProgramAssembler _publicOrganizationProgramAssambler;
        public OrganizationProgramController(
            OrganizationProgramAssembler? assambler, 
            PublicOrganizationProgramAssembler publicOrganizationProgramAssambler,
            IOrganizationProgramRepo? repo,
            IOrganizationProgramService? organizationProgramService
            ) : base(assambler, repo)
        {
            _organizationProgramService = organizationProgramService;
            _publicOrganizationProgramAssambler = publicOrganizationProgramAssambler;
        }

        // GET: /api/OrganizationProgram/publicprograms
        [HttpGet("publicprograms")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OrganizationProgramDto>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetPublicPrograms()
        {
            List<PublicOrganizationProgram> pop = new List<PublicOrganizationProgram>();
            if (_organizationProgramService is not null)
            {
                IQueryable<PublicOrganizationProgram>? publicProgramsQuery = _organizationProgramService.GetPublicOrganizationsPrograms();
                if (publicProgramsQuery is not null)
                {                    
                    pop = await publicProgramsQuery.ToListAsync();

                    return Ok(publicProgramsQuery.Select(pop =>_publicOrganizationProgramAssambler.ToDto(pop)));
                }
            }
            return NoContent();
        }
    }
}
