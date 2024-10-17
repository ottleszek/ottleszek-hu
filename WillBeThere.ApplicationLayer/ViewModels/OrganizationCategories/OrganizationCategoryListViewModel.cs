using MediatR;
using SharedDomainLayer.Responses;
using WillBeThere.ApplicationLayer.Commands.OrganizationCategories;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.ApplicationLayer.Queries.OrganizationCategories;

namespace WillBeThere.ApplicationLayer.ViewModels.OrganizationCategories
{
    public class OrganizationCategoryListViewModel : IOrganizationCategoryListViewModel
    {
        private readonly IMediator? _mediator;

        private OrganizationCategoryDto? _editedCategory;
        private List<OrganizationCategoryDto>? _organizationCategories = new List<OrganizationCategoryDto>();
        private List<OrganizationCategoryDto> _modifiedOrganizationCategories = new List<OrganizationCategoryDto>();

        private OrganizationCategoryDto? _selectedOrganizationCategory;

        private bool _isLoded = false;
        public bool _hasModifiedCategory => _modifiedOrganizationCategories.Any();
        public OrganizationCategoryListViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public bool IsLoded => _isLoded;
        public List<OrganizationCategoryDto> OrganizationCategories => _organizationCategories is not null ? _organizationCategories : new List<OrganizationCategoryDto>();
        public int NumberOfOrganizationCategories => OrganizationCategories.Count; 

        public bool SaveDisabled => !_hasModifiedCategory;
        public async Task GetCategoriesAsync()
        {
            if (_mediator is not null)
            {
                _organizationCategories = await _mediator.Send(new GetOrganizationsCategoriesQuery());
                _isLoded = true;
            }
        }

        public async Task Save()
        {
            if (_mediator is null)
                throw new Exception("Adatok mentése nem lehetséges!");
            else
            {
                var command = new SaveOrganizationCategoriesCommand(_modifiedOrganizationCategories);
                Response response = await _mediator.Send(command);
                if (response.HasError)
                    throw new Exception(response.Error);
            }
        }
        public void SetNewSelectedCategory(OrganizationCategoryDto newSelectedCategory)
        {
            _selectedOrganizationCategory = newSelectedCategory;
        }

        public void StartEditingCategory(OrganizationCategoryDto editedCategory)
        {
            _editedCategory = editedCategory;
        }

        public void AddToEditedCategory(OrganizationCategoryDto editedCategory)
        {
            if (editedCategory == _editedCategory)
                return;
            else
            {
                if (!_modifiedOrganizationCategories.Any(category => category.Id == editedCategory.Id))
                {
                    // Ezt a kategóriát még nem lett módosítva
                    _modifiedOrganizationCategories.Add(editedCategory);
                }
                else
                {
                    // Ezt a kategóriát már módosítva lett
                    if (IsModifiedCategorySameAsTheOriganl(editedCategory))
                    {
                        _modifiedOrganizationCategories.Remove(editedCategory);
                    }
                    else
                    {
                        // Ez a kategória már módísítva lett és nem egyezik meg az eredetivel
                        int index = _modifiedOrganizationCategories.FindIndex(category => category.Id == editedCategory.Id);

                        if (index != -1)
                            _modifiedOrganizationCategories[index] = editedCategory;
                    }
                }
            }
        }                  

        private bool IsModifiedCategorySameAsTheOriganl(OrganizationCategoryDto modifiedCategory)
        {
            OrganizationCategoryDto? orginalOrganizationCategory = _organizationCategories?.Find(category => category.Id == modifiedCategory.Id);
            return orginalOrganizationCategory != null && orginalOrganizationCategory.Equals(modifiedCategory);
        }
    }
}
