using Microsoft.AspNetCore.Mvc;
using SharedDomainLayer.Entities;
using SharedDomainLayer.Repos.Commands;
using SharedDomainLayer.Responses;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.UnitOfWork;


namespace WillBeThere.Backend.Controllers
{
    public abstract class BaseCommandController<TModel, TDto> : ControllerBase
        where TModel : class, IDbEntity<TModel>, new()
        where TDto : class, new()
    {
        protected readonly IAssembler<TModel, TDto>? _assambler;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IBaseCommandRepo? _repository;

        public BaseCommandController(IAssembler<TModel, TDto>? assambler, IBaseCommandRepo? repository, IUnitOfWork unitOfWork)
        {
            _assambler = assambler;
            _unitOfWork = unitOfWork;
            _repository = repository;
            if (repository is not null)
                unitOfWork.SetRepository(repository);
        }

        // POST: api/TModel
        [HttpPost()]
        public async Task<IActionResult> InsertAsync([FromBody] TDto entity)
        {
            Response response = new();
            if (_unitOfWork is not null && _assambler is not null && _repository != null)
            {

                response = _repository.Insert<TModel>(_assambler.ToModel(entity));
                if (response.HasError)
                    response.ClearAndAdd($"{response.Error}");
                else
                {

                    await _unitOfWork.SaveChangesAsync();
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
            if (_unitOfWork is not null && _assambler is not null && _repository != null)
            {
                response = _repository.Update<TModel>(_assambler.ToModel(entity));
                if (response.HasError)
                    response.ClearAndAdd($"{response.Error}");
                else
                {

                    await _unitOfWork.SaveChangesAsync();
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
            if (_unitOfWork is not null && _repository != null)
            {

                response = _repository.Delete<TModel>(id);
                if (response.HasError)
                    response.ClearAndAdd($"{response.Error}");
                else
                {

                    await _unitOfWork.SaveChangesAsync();
                    return Ok(response);
                }
            }
            response.ClearAndAdd("Az adatok törlése nem lehetséges!");
            return BadRequest(response);
        }
    }
}
