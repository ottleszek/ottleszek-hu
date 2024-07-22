namespace WillBeThere.Shared.Assamblers
{
    public class Assambler<TModel, TDto> 
        where TModel : class, new()
        where TDto: class, new()
    {
        public virtual TModel ToModel(TDto dto) { return new TModel(); }
        public virtual TDto ToDto(TModel model) { return new TDto(); }
    }
}
