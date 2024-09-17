using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Extensions.ModelExtensions
{
    public static class EditorExtension
    {
        public static EditorDto ToDto(this Editor model)
        {
            return new EditorDto
            {
                Id = model.Id,
            };
        }

        public static Editor ToModel(this EditorDto dto)
        {
            return new Editor
            {
                Id = dto.Id,
            };
        }
    }
}
