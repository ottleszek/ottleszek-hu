using Microsoft.AspNetCore.Mvc;
using WillBeThere.Application.Assemblers;
using WillBeThere.Application.Dtos;
using WillBeThere.Domain.Entites;
using WillBeThere.Infrastucture.Implementations.Repos.WillBeThere;

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
