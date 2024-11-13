using MediatR;
using Shared.ApplicationLayer.Persistence;
using Shared.DomainLayer.Responses;
using WillBeThere.ApplicationLayer.Transformers.Assemblers;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Commands.OrganizationCategories
{
    public class SaveOrganizationCategoriesCommandHandler : IRequestHandler<SaveOrganizationCategoriesCommand,Response>
    {
        private readonly IManyDataPersistenceService<OrganizationCategory> _dataPersistenceService;
        private readonly OrganizationCategoryAssembler _organizationCategoryAssembler;

        public SaveOrganizationCategoriesCommandHandler(IManyDataPersistenceService<OrganizationCategory>? organizationCategoryRepository, OrganizationCategoryAssembler? organizationCategoryAssembler)
        {
            _dataPersistenceService = organizationCategoryRepository ?? throw new ArgumentException(nameof(organizationCategoryRepository));
            _organizationCategoryAssembler = organizationCategoryAssembler ?? throw new ArgumentException(nameof(organizationCategoryAssembler));
        }

        public async Task<Response> Handle(SaveOrganizationCategoriesCommand request, CancellationToken cancellationToken)
        {
            return await _dataPersistenceService.UpdateMany(request.OrganizationCategories.Select(oc => _organizationCategoryAssembler.ToModel(oc)).ToList());

        }
    }
}
