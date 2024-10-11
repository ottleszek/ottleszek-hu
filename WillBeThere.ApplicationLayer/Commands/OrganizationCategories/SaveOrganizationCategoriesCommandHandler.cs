using MediatR;
using SharedApplicationLayer.Contracts.Persistence;
using SharedDomainLayer.Responses;
using WillBeThere.ApplicationLayer.Assemblers;

namespace WillBeThere.ApplicationLayer.Commands.OrganizationCategories
{
    public class SaveOrganizationCategoriesCommandHandler : IRequestHandler<SaveOrganizationCategoriesCommand,Response>
    {
        private readonly IDataPersistenceService _dataPersistenceService;
        private readonly OrganizationCategoryAssembler _organizationCategoryAssembler;

        public SaveOrganizationCategoriesCommandHandler(IDataPersistenceService organizationCategoryRepository, OrganizationCategoryAssembler organizationCategoryAssembler)
        {
            _dataPersistenceService = organizationCategoryRepository;
            _organizationCategoryAssembler = organizationCategoryAssembler;
        }

        public async Task<Response> Handle(SaveOrganizationCategoriesCommand request, CancellationToken cancellationToken)
        {

            return await _dataPersistenceService.SaveMany(request.OrganizationCategories.Select(oc => _organizationCategoryAssembler.ToModel(oc)));
        }
    }
}
