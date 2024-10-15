using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedApplicationLayer.Transformers;
using SharedApplicationLayer.Repos;
using SharedDomainLayer.Entities;
using SharedDomainLayer.Responses;
using WillBeThere.ApplicationLayer.Contracts.UnitOfWork;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.UnifOfWorks;

namespace WillBeThere.Backend.Controllers.Base
{
    public abstract class BaseController<TModel, TDto> : ControllerBase
        where TModel : class, IDbEntity<TModel>, new()
        where TDto : class, new()
    {
        protected readonly IAssembler<TModel, TDto>? _assambler;
        protected readonly IBaseCommandRepo? _commandRepo;
        protected readonly IBaseQueryRepo? _queryRepo;
        protected readonly IUnitOfWork? _unitOfWork;

        public BaseController(
            IAssembler<TModel, TDto>? assambler,
            IBaseQueryRepo? queryRepo,
            IBaseCommandRepo? commandRepo,
            IUnitOfWork unitOfWork
            )
        {
            _assambler = assambler;
            _unitOfWork = unitOfWork;
            _commandRepo = commandRepo;
            if (_commandRepo is not null)
                unitOfWork.SetRepository(_commandRepo);
            _queryRepo = queryRepo;
        }

        #region Commands API-s

        // POST: api/TModel
        [HttpPost()]
        public async Task<IActionResult> InsertAsync([FromBody] TDto entity)
        {
            Response response = new();
            if (_unitOfWork is not null && _assambler is not null && _commandRepo != null)
            {

                response = _commandRepo.Insert<TModel>(_assambler.ToModel(entity));
                if (response.HasError)
                    response.ClearAndAdd($"{response.Error}");
                else
                {
                    try
                    {
                        await _unitOfWork.SaveChangesAsync();
                    }
                    catch (SaveChangesException ex)
                    {
                        Console.WriteLine(ex.Message);
                        return StatusCode(StatusCodes.Status500InternalServerError, "Nem sikerült menteni az új adatokat!");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return StatusCode(StatusCodes.Status500InternalServerError, "Ismeretlen hiba törént!");
                    }
                    return Ok(response);
                }
            }
            response.ClearAndAdd("Az új adatok mentése nem lehetséges!");
            return BadRequest(response);
        }

        // PUT: api/TModel/
        [HttpPut()]
        public async Task<ActionResult> UpdateAsync([FromBody] TDto entity)
        {
            Response response = new();
            if (_unitOfWork is not null && _assambler is not null && _commandRepo != null)
            {
                response = _commandRepo.Update<TModel>(_assambler.ToModel(entity));
                if (response.HasError)
                    response.ClearAndAdd($"{response.Error}");
                else
                {

                    try
                    {
                        await _unitOfWork.SaveChangesAsync();
                    }
                    catch (SaveChangesException ex)
                    {
                        Console.WriteLine(ex.Message);
                        return StatusCode(StatusCodes.Status500InternalServerError, "Nem sikerült frissíteni az új adatokat!");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return StatusCode(StatusCodes.Status500InternalServerError, "Ismeretlen hiba törént!");
                    }
                    return Ok(response);
                }
            }
            response.ClearAndAdd("Az adatok frissítés nem lehetséges!");
            return BadRequest(response);
        }

        // DELETE: api/TModel/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            Response response = new();
            if (_unitOfWork is not null && _commandRepo != null)
            {

                response = (Response)_commandRepo.Delete<TModel>(id);
                if (response.HasError)
                    response.ClearAndAdd($"{response.Error}");
                else
                {
                    try
                    {
                        await _unitOfWork.SaveChangesAsync();
                    }
                    catch (SaveChangesException ex)
                    {
                        Console.WriteLine(ex.Message);
                        return StatusCode(StatusCodes.Status500InternalServerError, "Nem sikerült törölni az adatokat!");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return StatusCode(StatusCodes.Status500InternalServerError, "Ismeretlen hiba törént!");
                    }
                    return Ok(response);
                }
            }
            response.ClearAndAdd("Az adatok törlése nem lehetséges!");
            return BadRequest(response);
        }
        #endregion

        #region Queryies API-s
        // GET: api/TModel/
        [HttpGet]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual async Task<IActionResult> SelectAsync()
        {
            List<TModel>? entities = new();

            if (_queryRepo != null && _assambler is not null)
            {
                entities = await _queryRepo.SelectAllAsync<TModel>();
                return Ok(entities.Select(entity => _assambler.ToDto(entity)));
            }
            return NoContent();
        }

        // GET: api/TModel/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            TModel? entity = new();
            if (_queryRepo is not null && _assambler is not null)
            {
                entity = await _queryRepo.GetByIdAsync<TModel>(id);
                if (entity != null)
                    return Ok(_assambler.ToDto(entity));
                else
                    return Ok(_assambler.ToDto(new TModel()));
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }
        #endregion
    }
}
