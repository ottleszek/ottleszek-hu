using Microsoft.AspNetCore.Mvc;
using SharedDomainLayer.Entities;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.Base;

namespace WillBeThere.Backend.Controllers
{
    public abstract class BaseQueryController<TModel, TDto> : ControllerBase
        where TModel : class, IDbEntity<TModel>, new()
        where TDto : class, new()
    {
        protected readonly IAssembler<TModel, TDto>? _assambler;
        protected readonly IBaseQueryRepo? _repo;

        public BaseQueryController(IAssembler<TModel, TDto>? assambler, IBaseQueryRepo? repo)
        {
            _assambler = assambler;
            _repo = repo;
        }

        // GET: api/TModel/
        [HttpGet]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual async Task<IActionResult> SelectAsync()
        {
            List<TModel>? entities = new();

            if (_repo != null && _assambler is not null)
            {
                entities = await _repo.SelectAllAsync<TModel>();
                return Ok(entities.Select(entity => _assambler.ToDto(entity)));
            }
            return NoContent();
        }

        // GET: api/TModel/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            TModel? entity = new();
            if (_repo is not null && _assambler is not null)
            {
                entity = await _repo.GetByIdAsync<TModel>(id);
                if (entity != null)
                    return Ok(_assambler.ToDto(entity));
                else
                    return Ok(_assambler.ToDto(new TModel()));
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }
    }
}
