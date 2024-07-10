using WillBeThere.Shared.DataBroker;

namespace WillBeThere.HttpService.HttpService
{
    public interface IBaseHttpService<TEntityDto> :  IDataBroker where TEntityDto : class, new ()
    {
    }
}
