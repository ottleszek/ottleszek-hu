using MediatR;
using SharedApplicationLayer.Contracts.Persistence;
using SharedDomainLayer.Responses;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Commands.OrganizationCategories
{
    public class SaveOrganizationCategoriesCommandHandler : IRequestHandler<SaveOrganizationCategoriesCommand,Response>
    {
        private readonly IDataPersistenceService<OrganizationCategoryDto,OrganizationCategoryAssembler>? _dataPersistenceService;
        private readonly OrganizationCategoryAssembler _organizationCategoryAssembler;

        public SaveOrganizationCategoriesCommandHandler(IDataPersistenceService<OrganizationCategoryDto, OrganizationCategoryAssembler>? organizationCategoryRepository, OrganizationCategoryAssembler organizationCategoryAssembler)
        {
            _dataPersistenceService = organizationCategoryRepository;
            _organizationCategoryAssembler = organizationCategoryAssembler;
        }

        public async Task<Response> Handle(SaveOrganizationCategoriesCommand request, CancellationToken cancellationToken)
        {
            if (_dataPersistenceService is null)
                return new Response("Kategoróiák mentése nem lehetséges!");
            return await _dataPersistenceService.SaveMany<OrganizationCategory>(request.OrganizationCategories.Select(oc => _organizationCategoryAssembler.ToModel(oc)).ToList());

        }
    }
}
