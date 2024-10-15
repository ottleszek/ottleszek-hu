﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using WillBeThere.ApplicationLayer.Commands.OrganizationCategories;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.ApplicationLayer.Contracts.UnitOfWork;
using WillBeThere.ApplicationLayer.Repos.Base;
using WillBeThere.ApplicationLayer.Transformers.Assemblers;
using WillBeThere.Backend.Controllers.Base;
using WillBeThere.DomainLayer.Entites;
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

        [HttpPost("bulk")]
        public async Task<IActionResult> SaveCategories([FromBody] List<OrganizationCategoryDto> organizationCategoryDtos)
        {
            if (organizationCategoryDtos == null || !organizationCategoryDtos.Any())
            {
                return BadRequest("A szervezeti kategóriák listája üres.");
            }
            var command = new SaveOrganizationCategoriesCommand(organizationCategoryDtos);

            if (_mediator is null)
                return BadRequest("Szervezeti kategóriák mentése nem lehetséges.");
            

            var result = await _mediator.Send(command);
                if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("A szervezeti kategóriák mentése nem sikerült.");
            }
        }
    }
}
