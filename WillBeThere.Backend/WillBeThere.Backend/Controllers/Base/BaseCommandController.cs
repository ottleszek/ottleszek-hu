using Microsoft.AspNetCore.Mvc;
using Shared.ApplicationLayer.Repos.Commands;
using Shared.ApplicationLayer.Repos.UnitOfWork;
using Shared.ApplicationLayer.Transformers;
using Shared.DomainLayer.Entities;
using Shared.DomainLayer.Responses;


namespace WillBeThere.Backend.Controllers.Base
{
    public abstract class BaseCommandController<TModel, TDto> : ControllerBase
        where TModel : class, IDbEntity<TModel>, new()
        where TDto : class, new()
    {
        protected readonly IAssembler<TModel, TDto>? _assambler;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ICommandGenericMethodRepo? _repository;

        public BaseCommandController(IAssembler<TModel, TDto>? assambler, ICommandGenericMethodRepo? repository, IUnitOfWork unitOfWork)
        {
            _assambler = assambler;
            _unitOfWork = unitOfWork;
            _repository = repository;
            /*if (repository is not null)
                unitOfWork.SetRepository(repository);*/
        }

        // POST: api/TModel
        [HttpPost()]
        public async Task<IActionResult> InsertAsync([FromBody] TDto entity)
        {
            Response response = new();
            if (_unitOfWork is not null && _assambler is not null && _repository != null)
            {

                response = await _repository.InsertAsync<TModel>(_assambler.ToModel(entity));
                if (response.HasError)
                    response.SetNewError($"{response.Error}");
                else
                {

                    await _unitOfWork.SaveChangesAsync();
                    return Ok(response);
                }
            }
            response.SetNewError("Az új adatok mentése nem lehetséges!");
            return BadRequest(response);
        }

        // PUT: api/TModel/
        [HttpPut()]
        public async Task<ActionResult> UpdateAsync([FromBody] TDto entity)
        {
            Response response = new();
            if (_unitOfWork is not null && _assambler is not null && _repository != null)
            {
                response = await _repository.UpdateAsync<TModel>(_assambler.ToModel(entity));
                if (response.HasError)
                    response.SetNewError($"{response.Error}");
                else
                {

                    await _unitOfWork.SaveChangesAsync();
                    return Ok(response);
                }
            }
            response.SetNewError("Az adatok frissítés nem lehetséges!");
            return BadRequest(response);
        }

        // DELETE: api/TModel/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            Response response = new();
            if (_unitOfWork is not null && _repository != null)
            {

                response = await _repository.DeleteAsync<TModel>(id);
                if (response.HasError)
                    response.SetNewError($"{response.Error}");
                else
                {

                    await _unitOfWork.SaveChangesAsync();
                    return Ok(response);
                }
            }
            response.SetNewError("Az adatok törlése nem lehetséges!");
            return BadRequest(response);
        }
    }
}
