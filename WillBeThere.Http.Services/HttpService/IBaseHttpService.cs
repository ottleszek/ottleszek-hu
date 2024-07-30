using WillBeThere.Shared.DataBroker;

namespace WillBeThere.HttpService.HttpService
{
    public interface IBaseHttpService<TEntityDto> : IDtoDataBroker<TEntityDto> where TEntityDto : class, new ()
    {

    }
}
