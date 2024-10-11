using MediatR;
using Microsoft.AspNetCore.Mvc;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.ApplicationLayer.Contracts.UnitOfWork;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Repos.Base;
using WillBeThere.DomainLayer.Services.Base;
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
             IMediator? mediator,
        OrganizationCategoryAssembler? assambler, 
            IBaseOrganizationCategoryService? baseOrganizationCategoryService,
            IOrganizationCategoryQueryRepo? organizationCategoryQueryRepo,
            IBaseOrganizationCategoryCommandRepo? organizationCategoryCommandRepo,
            IUnitOfWork unitOfWork
            ) : base(assambler, organizationCategoryQueryRepo,organizationCategoryCommandRepo, unitOfWork)
        {            
            _mediator = mediator ?? throw new ArgumentNullException(nameof(_mediator));
            _baseOrganizationCategoryService = baseOrganizationCategoryService ?? throw new ArgumentNullException(nameof(_baseOrganizationCategoryService));
        }
    }
}
