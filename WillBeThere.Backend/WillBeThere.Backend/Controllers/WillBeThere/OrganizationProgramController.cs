using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using WillBeThere.Backend.Repos.WillBeThere;
using WillBeThere.Backend.Services;
using WillBeThere.Shared.Assamblers;
using WillBeThere.Shared.Assamblers.ResultModels;
using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Models;
using WillBeThere.Shared.Models.ResultModels;

namespace WillBeThere.Backend.Controllers.WillBeThere
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationProgramController : IncludedController<OrganizationProgram, OrganizationProgramDto>
    {
        private readonly IOrganizationProgramService? _organizationProgramService;
        private readonly PublicOrganizationProgramAssambler _publicOrganizationProgramAssambler;
        public OrganizationProgramController(
            OrganizationProgramAssambler? assambler, 
            PublicOrganizationProgramAssambler publicOrganizationProgramAssambler,
            IOrganizationProgramRepo? repo,
            IOrganizationProgramService? organizationProgramService
            ) : base(assambler, repo)
        {
            _organizationProgramService = organizationProgramService;
            _publicOrganizationProgramAssambler = publicOrganizationProgramAssambler;
        }

        // GET: /api/publicprograms
        [HttpGet("OrganizationProgram/publicprograms")]
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
