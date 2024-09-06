using WillBeThere.ApplicationLayer.DataBrokers;

namespace WillBeThere.ApplicationLayer.Services.HttpService
{
    public interface IBaseHttpService<TEntityDto> : IDtoDataBroker<TEntityDto> where TEntityDto : class, new ()
    {

    }
}
