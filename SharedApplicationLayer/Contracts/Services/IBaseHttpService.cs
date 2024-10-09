using SharedApplicationLayer.Repos;

namespace SharedApplicationLayer.Contracts.Services
{
    public interface IBaseHttpService<TEntityDto> : IBaseQueryRepo<TEntityDto>, IBaseCommandRepo<TEntityDto> where TEntityDto : class, new()
    {

    }
}
