namespace SharedApplicationLayer.Transformers
{
    public interface IDomainDtoConterter<TModel, TDto>
    {
        public List<TDto> ToDto(List<TModel> models);
        public List<TModel> ToModel(List<TDto> dtos);
    }
}
