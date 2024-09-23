using MediatR;
using Microsoft.AspNetCore.Mvc;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
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
        private readonly IOrganizationCategoryQueryRepo? _organizationCategoryQueryRepo;
        private readonly IBaseOrganizationCategoryService? _baseOrganizationCategoryService;
        private 
        public OrganizationCategoryController(
             IMediator? _mediator,
        OrganizationCategoryAssembler? assambler, 
            IBaseOrganizationCategoryService? baseOrganizationCategoryService,
            IOrganizationCategoryQueryRepo? organizationCategoryQueryRepo
            ) : base(assambler, organizationCategoryQueryRepo)
        {
            _mediator = _mediator ?? throw new ArgumentNullException(nameof(_mediator));
            _organizationCategoryQueryRepo = _organizationCategoryQueryRepo ?? throw new ArgumentNullException(nameof(_organizationCategoryQueryRepo));
            _baseOrganizationCategoryService = _baseOrganizationCategoryService ?? throw new ArgumentNullException(nameof(_baseOrganizationCategoryService));

        }
    }
}
