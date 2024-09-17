
using WillBeThere.ApplicationLayer.Contracts.Base;

namespace WillBeThere.ApplicationLayer.Contracts.Services.HttpService
{
    public interface IBaseHttpService<TEntityDto> : IBaseQueryHttpService<TEntityDto>, IBaseCommandHttpService<TEntityDto> where TEntityDto : class, new()
    {

    }
}
