using WillBeThere.Application.Dtos;
using WillBeThere.Domain.Entites;

namespace WillBeThere.Domain.Extensions.ModelExtensions
{
    public static class OrganizationProgramExtension
    {
        public static OrganizationProgramDto ToDto(this OrganizationProgram model)
        {
            return new OrganizationProgramDto
            {
                Id = model.Id,
                Title = model.Title,
                Start = model.Start,
                End = model.End,
                IsDeffered = model.IsDeffered,
                IsPublic = model.IsPublic,
                OrganizationOwnerId = model.OrganizationId,
                ProgramOwnerId = model.ProgramOwnerId,
                AddressId = model.AddressId,
            };
        }

        public static OrganizationProgram ToModel(this OrganizationProgramDto dto)
        {
            return new OrganizationProgram
            {
                Id = dto.Id,
                Title = dto.Title,
                Start = dto.Start,
                End = dto.End,
                IsPublic = dto.IsPublic,
                IsDeffered = dto.IsDeffered,
                OrganizationId = dto.OrganizationOwnerId,
                ProgramOwnerId = dto.ProgramOwnerId,
                AddressId = dto.AddressId,
            };
        }
    }
}
