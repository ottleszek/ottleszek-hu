using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.ApplicationLayer.Repos;
using Shared.ApplicationLayer.Repos.Queries;
using Shared.ApplicationLayer.Transformers;
using Shared.DomainLayer.Entities;

namespace WillBeThere.Backend.Controllers.Base
{
    public class IncludedController<TModel, TDto> : BaseQueryController<TModel, TDto>
        where TModel : class, IDbEntity<TModel>, new()
        where TDto : class, new()
    {

        public IncludedController(
            IAssembler<TModel, TDto>? assambler,
            IQueryGenericMethodRepo? baseRepo
            ) : base(assambler, baseRepo)
        {
        }

        // GET: api/TModel/included
        [HttpGet("included")]
        public virtual async Task<IActionResult> SelectAllAsyncIncluded()
        {
            List<TModel>? entities = new();

            if (_baseRepo != null && _assambler is not null)
            {
                IIncludedQueryRepo includedRepo = (IIncludedQueryRepo)_baseRepo;
                IQueryable<TModel>? query = includedRepo.SelectAllInluded<TModel>();
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
