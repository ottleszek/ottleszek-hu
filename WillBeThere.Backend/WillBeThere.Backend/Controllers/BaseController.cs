using Microsoft.AspNetCore.Mvc;
using WillBeThere.Shared.Assamblers;
using WillBeThere.Shared.DataBroker;
using WillBeThere.Shared.Models.Guids;
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
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual async Task<IActionResult> SelectAsync()
        {
            List<TModel>? entities = new();

            if (_repo != null && _assambler is not null)
            {
                entities = await _repo.SelectAsync<TModel>();
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


        // POST: api/TModel
        [HttpPost()]
        public async Task<IActionResult> InsertAsync([FromBody] TDto entity)
        {
            ControllerResponse response = new();
            if (_repo is not null && _assambler is not null)
            {
                response = (ControllerResponse)await _repo.InsertAsync(_assambler.ToModel(entity));
                if (!response.HasError)
                    return Ok(response);
                else
                    response.ClearAndAdd($"{response.Error}");
            }
            response.ClearAndAdd("Az új adatok mentése nem lehetséges!");
            return BadRequest(response);
        }

        // PUT: api/TModel/
        [HttpPut()]
        public async Task<ActionResult> UpdateAsync([FromBody] TDto entity)
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
    }
}
