namespace Shared.ApplicationLayer.Transformers
{
    public class DomainDtoConverter<TModel, TDto, TAssembler> : IDomainDtoConterter<TModel,TDto>
        where TModel : class, new()
        where TDto : class, new()   
        where TAssembler : class, IAssembler<TModel, TDto>, new()
    {
        private readonly TAssembler _assembler;

        public DomainDtoConverter(TAssembler assembler)
        {
            _assembler = assembler;
        }

        public List<TDto> ToDto(List<TModel> models)
        {
            return models.Select(model => _assembler.ToDto(model)).ToList();
        }

        public List<TModel> ToModel(List<TDto> dtos)
        {
            return dtos.Select(dto => _assembler.ToModel(dto)).ToList();
        }
    }
}
