using WillBeThere.Application.DataBroker;

namespace WillBeThere.HttpService.HttpService
{
    public interface IBaseHttpService<TEntityDto> : IDtoDataBroker<TEntityDto> where TEntityDto : class, new ()
    {

    }
}
