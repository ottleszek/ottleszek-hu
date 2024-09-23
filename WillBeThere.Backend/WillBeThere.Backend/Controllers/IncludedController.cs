using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedDomainLayer.Entities;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.Base;

namespace WillBeThere.Backend.Controllers
{
    public class IncludedController<TModel, TDto> : BaseQueryController<TModel, TDto>
        where TModel : class, IDbEntity<TModel>, new()
        where TDto : class, new()
    {
        public IncludedController(IAssembler<TModel, TDto>? assambler, IIncludedQueryRepo? includedRepo) : base(assambler, includedRepo)
        {
        }

        // GET: api/TModel/included
        [HttpGet("included")]
        public virtual async Task<IActionResult> SelectAllAsyncIncluded()
        {
            List<TModel>? entities = new();

            if (_baseRepo != null && _assambler is not null)
            {
                IIncludedQueryRepo includedRepo = (IIncludedQueryRepo) _baseRepo;
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
