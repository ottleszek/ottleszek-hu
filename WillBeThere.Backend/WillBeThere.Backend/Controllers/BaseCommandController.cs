using Microsoft.AspNetCore.Mvc;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Responses;
using WillBeThere.DomainLayer.Entities.DbIds;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.UnifOfWorks;


namespace WillBeThere.Backend.Controllers
{
    public abstract class BaseCommandController<TModel, TDto> : ControllerBase
        where TModel : class, IDbEntity<TModel>, new()
        where TDto : class, new()
    {
        protected readonly IAssembler<TModel, TDto>? _assambler;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IBaseCommandRepo? _repo;

        public BaseCommandController(IAssembler<TModel, TDto>? assambler, IBaseCommandRepo? repository, IUnitOfWork unitOfWork)
        {
            _assambler = assambler;
            _unitOfWork = unitOfWork;
            _repo=unitOfWork.AddRepository<IBaseCommandRepo, TModel>(repository);
        }

        // POST: api/TModel
        [HttpPost()]
        public async Task<IActionResult> InsertAsync([FromBody] TDto entity)
        {
            ControllerResponse response = new();
            if (_unitOfWork is not null && _assambler is not null && _repo != null)
            {

                response = (ControllerResponse)_repo.Insert<TModel>(_assambler.ToModel(entity));
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
            ControllerResponse response = new();
            if (_unitOfWork is not null && _assambler is not null && _repo != null)
            {
                response = (ControllerResponse)repo.Update<TModel>(_assambler.ToModel(entity));
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
            ControllerResponse response = new();
            if (_unitOfWork is not null && _repo != null)
            {

                response = (ControllerResponse)repo.Delete<TModel>(id);
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
