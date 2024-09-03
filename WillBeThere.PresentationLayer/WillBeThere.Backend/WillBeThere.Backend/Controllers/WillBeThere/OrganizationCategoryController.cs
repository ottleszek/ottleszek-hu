using Microsoft.AspNetCore.Mvc;
using WillBeThere.Backend.Repos.WillBeThere;
using WillBeThere.Shared.Assemblers;
using WillBeThere.Shared.DataBroker;
using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Models;

namespace WillBeThere.Backend.Controllers.WillBeThere
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationCategoryController : IncludedController<OrganizationCategory, OrganizationCategoryDto>
    {
        public OrganizationCategoryController(OrganizationCategoryAssembler? assambler, IOrganizationCategoryRepo? repo) : base(assambler, repo)
        {
        }
    }
}
