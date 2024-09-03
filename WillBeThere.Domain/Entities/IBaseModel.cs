
namespace WillBeThere.Domain.Entites
{
    public  interface IBaseModel<TModel,TDto> 
        where TModel : class, new()
        where TDto : class, new()
    {
        public TDto ToDto(TModel model);
    }
}
