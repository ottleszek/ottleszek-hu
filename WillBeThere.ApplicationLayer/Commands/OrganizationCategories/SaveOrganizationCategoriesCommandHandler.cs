using MediatR;
using SharedDomainLayer.Responses;
using WillBeThere.ApplicationLayer.Contracts.Repositories;

namespace WillBeThere.ApplicationLayer.Commands.OrganizationCategories
{
    public class SaveOrganizationCategoriesCommandHandler : IRequestHandler<SaveOrganizationCategoriesCommand,Response>
    {
        private readonly IOrganizationCategoryRepository _repository;

        public SaveOrganizationCategoriesCommandHandler(IOrganizationCategoryRepository organizationCategoryRepository)
        {
            _repository = organizationCategoryRepository;
        }

        public async Task<Response> Handle(SaveOrganizationCategoriesCommand request, CancellationToken cancellationToken)
        {
            return await _repository.SaveOrganizationCategories(request.OrganizationCategories);
        }
    }
}
