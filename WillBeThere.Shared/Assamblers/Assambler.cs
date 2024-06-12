namespace WillBeThere.Shared.Assamblers
{
    public abstract class Assambler<TModel, TDto>
    {
        public abstract TModel ToModel(TDto dto);
        public abstract TDto ToDto(TModel model);
    }
}
