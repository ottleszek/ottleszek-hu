using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WillBeThere.Backend.Repos.WillBeThere;
using WillBeThere.Backend.Services;
using WillBeThere.Shared.Assamblers;
using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Models;
using WillBeThere.Shared.Models.ResultModels;

namespace WillBeThere.Backend.Controllers.WillBeThere
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationProgramController : IncludedController<OrganizationProgram, OrganizationProgramDto>
    {
        public readonly IOrganizationProgramService? _organizationProgramService;
        public OrganizationProgramController(
            OrganizationProgramAssambler? assambler, 
            IOrganizationProgramRepo? repo,
            IOrganizationProgramService? organizationProgramService
            ) : base(assambler, repo)
        {
            _organizationProgramService = organizationProgramService;
        }

        [HttpGet("api/publicprograms")]
        public async Task<IActionResult> GetPublicPrograms()
        {
            List<PublicOrganizationProgram> pop = new List<PublicOrganizationProgram>();
            return Ok(_organizationProgramService.GetPublicOrganizationPrograms().ToListAsync());

        }
    }
}
