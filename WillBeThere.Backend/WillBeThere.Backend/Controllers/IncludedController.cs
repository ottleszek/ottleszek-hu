using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WillBeThere.Shared.Assamblers;
using WillBeThere.Shared.DataBroker;
using WillBeThere.Shared.Models.Guids;

namespace WillBeThere.Backend.Controllers
{
    public class IncludedController<TModel, TDto> : BaseController<TModel, TDto>
        where TModel : class, IDbEntity<TModel>, new()
        where TDto : class, new()
    {
        private readonly IIncludedDataBroker? _includedRepo;
        public IncludedController(Assambler<TModel, TDto>? assambler, IIncludedDataBroker? repo) : base(assambler, (IDataBroker?) repo)
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
