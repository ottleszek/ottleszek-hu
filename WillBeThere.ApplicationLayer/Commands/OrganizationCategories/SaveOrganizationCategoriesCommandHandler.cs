using MediatR;
using SharedDomainLayer.Responses;
using WillBeThere.DomainLayer.Repos;

namespace WillBeThere.ApplicationLayer.Commands.OrganizationCategories
{
    public class SaveOrganizationCategoriesCommandHandler : IRequestHandler<SaveOrganizationCategoriesCommand, Response>
    {
        private readonly IOrganizationCategoryCommandRepo _repository;

        public SaveOrganizationCategoriesCommandHandler(IOrganizationCategoryCommandRepo repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(SaveOrganizationCategoriesCommand request, CancellationToken cancellationToken)
        {
            return await _repository.Save(request.OrganizationCategories);
        }
    }
}