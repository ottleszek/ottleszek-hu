using SharedApplicationLayer.Assamblers;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.ApplicationLayer.Extensions.ModelExtensions;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Assemblers
{
    public class EditorAssambler : IAssembler<Editor, EditorDto>
    {
        public EditorDto ToDto(Editor model)
        {
            return model.ToDto();
        }

        public Editor ToModel(EditorDto dto)
        {
            return dto.ToModel();
        }
    }
}
