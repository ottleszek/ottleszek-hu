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
        private readonly IIncludedQueryRepo? _includedRepo;
        public IncludedController(IAssembler<TModel, TDto>? assambler, IIncludedQueryRepo? repo) : base(assambler, repo)
        {
            _includedRepo = repo;
        }

        // GET: api/TModel/included
        [HttpGet("included")]
        public virtual async Task<IActionResult> SelectAllAsyncIncluded()
        {
            List<TModel>? entities = new();

            if (_includedRepo != null && _assambler is not null)
            {
                IQueryable<TModel>? query = _includedRepo.SelectAllInluded<TModel>();
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
