using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WillBeThere.Backend.Repos;
using WillBeThere.Shared.Assamblers;
using WillBeThere.Shared.Models;
using WillBeThere.Shared.Responses;

namespace WillBeThere.Backend.Controllers
{
    public abstract class BaseController<TModel, TDto> : ControllerBase
        where TModel : class, IDbEntity<TModel>, new()
        where TDto : class, new()
    {
        protected readonly Assambler<TModel, TDto>? _assambler;
        protected readonly IDataBroker? _repo;

        public BaseController(Assambler<TModel, TDto>? assambler, IDataBroker? repo)
        {
            _assambler = assambler;
            _repo = repo;
        }

        // GET: api/TModel/
        [HttpGet]
        public virtual async Task<IActionResult> SelectAllAsync()
        {
            List<TModel>? entities = new();

            if (_repo != null && _assambler is not null)
            {
                entities = await _repo.FindAll<TModel>().ToListAsync();
                return Ok(entities.Select(entity => _assambler.ToDto(entity)));
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        // GET: api/TModel/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            TModel? entity = new();
            if (_repo is not null && _assambler is not null)
            {
                entity = await _repo.FindByCondition<TModel>(entity => entity.Id == id).FirstOrDefaultAsync();
                if (entity != null)
                    return Ok(_assambler.ToDto(entity));
                else
                    return Ok(_assambler.ToDto(new TModel()));
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        // PUT: api/TModel/
        [HttpPut()]
        public async Task<ActionResult> UpdateAsync(TDto entity)
        {
            ControllerResponse response = new();
            if (_repo is not null && _assambler is not null)
            {
                response = (ControllerResponse) await _repo.UpdateAsync(_assambler.ToModel(entity));
                if (!response.HasError)
                    return Ok(response);
                else
                    response.ClearAndAdd($"{response.Error}");
            }
            response.ClearAndAdd("Az adatok frissítés nem lehetséges!");
            return BadRequest(response);
        }

        // DELETE: api/TModel/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            ControllerResponse response = new();
            if (_repo is not null)
            {
                response = (ControllerResponse) await _repo.DeleteAsync<TModel>(id);
                if (!response.HasError)
                    return Ok(response);
                else
                    response.ClearAndAdd($"{response.Error}");
            }        
            response.ClearAndAdd("Az adatok törlése nem lehetséges!");
            return BadRequest(response);
        }

        // POST: api/TModel
        [HttpPost()]
        public async Task<IActionResult> InsertAsync(TDto entity)
        {
            ControllerResponse response = new();
            if (_repo is not null && _assambler is not null)
            {
                response = (ControllerResponse) await _repo.CreateAsync(_assambler.ToModel(entity));
                if (!response.HasError)
                    return Ok(response);
                else
                    response.ClearAndAdd($"{response.Error}");
            }
            response.ClearAndAdd("Az új adatok mentése nem lehetséges!");
            return BadRequest(response);
        }
    }
}
