using MediatR;
using Microsoft.AspNetCore.Mvc;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.ApplicationLayer.Contracts.Queries.OrganizationCategories;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Services;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos.Interfaces;

namespace WillBeThere.Backend.Controllers.WillBeThere
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationCategoryController : IncludedController<OrganizationCategory, OrganizationCategoryDto>
    {
        private readonly IMediator? _mediator;
        private readonly IBaseOrganizationCategoryService? _baseOrganizationCategoryService;

        public OrganizationCategoryController(
             IMediator? _mediator,
        OrganizationCategoryAssembler? assambler, 
            IBaseOrganizationCategoryService? baseOrganizationCategoryService,
            IOrganizationCategoryQueryRepo? organizationCategoryQueryRepo
            ) : base(assambler, organizationCategoryQueryRepo)
        {
            _mediator = _mediator ?? throw new ArgumentNullException(nameof(_mediator));
            _baseOrganizationCategoryService = _baseOrganizationCategoryService ?? throw new ArgumentNullException(nameof(_baseOrganizationCategoryService));
        }

        // Get: /api/OrganizationCategory
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OrganizationCategoryDto>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetOrganizationPrograms()
        {
            List<OrganizationCategory> oc = new List<OrganizationCategory>();
            if (_mediator is not null && _assambler is not null)
            {
                oc = await _mediator.Send(new GetOrganizationsCategoriesQuery());
                return Ok(oc.Select(oc => _assambler.ToDto(oc)));
            }
            return NoContent();
        }
    }
}
