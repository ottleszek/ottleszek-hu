﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedApplicationLayer.Assamblers;
using SharedDomainLayer.Entities;
using SharedDomainLayer.Repos.Commands;
using WillBeThere.ApplicationLayer.Contracts.UnitOfWork;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.Base;

namespace WillBeThere.Backend.Controllers
{
    public class IncludedController<TModel, TDto> : BaseController<TModel, TDto>
        where TModel : class, IDbEntity<TModel>, new()
        where TDto : class, new()
    {
        public IncludedController(
            IAssembler<TModel, TDto>? assambler,
            IBaseQueryRepo? queryRepo,
            IBaseCommandRepo2? commandRepo,
            IUnitOfWork unitOfWork
            ) : base(assambler,queryRepo, commandRepo, unitOfWork)
        {
        }

        // GET: api/TModel/included
        [HttpGet("included")]
        public virtual async Task<IActionResult> SelectAllAsyncIncluded()
        {
            List<TModel>? entities = new();

            if (_queryRepo != null && _assambler is not null)
            {
                IIncludedQueryRepo includedRepo = (IIncludedQueryRepo)_queryRepo;
                IQueryable<TModel>? query =  includedRepo.SelectAllInluded<TModel>();
                if (query != null)
                {
                    entities = await query.ToListAsync();
                    return Ok(entities.Select(entity => _assambler.ToDto(entity)));
                }
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }
    }
}
