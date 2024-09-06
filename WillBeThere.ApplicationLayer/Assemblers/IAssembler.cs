namespace WillBeThere.ApplicationLayer.Assemblers
{
    public interface IAssembler<TModel, TDto>
        where TModel :  class, new()
        where TDto : class, new()
    {
        public TModel ToModel(TDto dto);
        public TDto ToDto(TModel model);
    }
}
