
using SharedDomainLayer.Entities;

namespace WillBeThere.ApplicationLayer.Contracts.Dtos
{
    public class EditorDto : IDbEntity<EditorDto>
    {
        public Guid Id { get; set; }

    }
}
