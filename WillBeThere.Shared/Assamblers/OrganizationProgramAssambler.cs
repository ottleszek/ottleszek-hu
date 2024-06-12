using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Assamblers
{
    public class OrganizationProgramAssambler : Assambler<OrganizationProgram, OrganizationProgramDto>
    {
        public override OrganizationProgramDto ToDto(OrganizationProgram model)
        {
            return new OrganizationProgramDto
            {
                Id = model.Id,
                Title = model.Title,
                Start = model.Start,
                End = model.End,
                IsDeffered = model.IsDeffered,
                IsPublic = model.IsPublic,
                OrganizationOwnerId = model.OrganizationOwnerId,
                ProgramOwnerId = model.ProgramOwnerId,
                AddressId = model.AddressId,

            };
        }

        public override OrganizationProgram ToModel(OrganizationProgramDto dto)
        {
            return new OrganizationProgram
            {
                Id = dto.Id,
                Title = dto.Title,
                Start = dto.Start,
                End = dto.End,
                IsPublic= dto.IsPublic,
                IsDeffered= dto.IsDeffered,
                OrganizationOwnerId = dto.OrganizationOwnerId,
                ProgramOwnerId = dto.ProgramOwnerId,
                AddressId= dto.AddressId,
            };
        }
    }
}
