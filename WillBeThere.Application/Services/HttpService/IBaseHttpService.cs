using WillBeThere.Application.DataBrokers;

namespace WillBeThere.Application.Services.HttpService
{
    public interface IBaseHttpService<TEntityDto> : IDtoDataBroker<TEntityDto> where TEntityDto : class, new ()
    {

    }
}
