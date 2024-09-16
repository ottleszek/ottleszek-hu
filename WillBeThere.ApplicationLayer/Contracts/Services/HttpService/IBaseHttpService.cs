using WillBeThere.ApplicationLayer.DataBrokers;

namespace WillBeThere.ApplicationLayer.Contracts.Services.HttpService
{
    public interface IBaseHttpService<TEntityDto> : IDtoDataBroker<TEntityDto> where TEntityDto : class, new()
    {

    }
}
