using SharedDomainLayer.Responses;
using WillBeThere.ApplicationLayer.Contracts.Repositories;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.ViewModels.OrganizationCategories
{
    public class OrganizationCategoryListViewModel : IOrganizationCategoryListViewModel
    {
        private readonly IOrganizationCategoryRepository? _organizationCategoryRepository;

        private OrganizationCategory? _editedCategory;
        private List<OrganizationCategory>? _organizationCategories = new List<OrganizationCategory>();
        private List<OrganizationCategory> _modifiedOrganizationCategories = new List<OrganizationCategory>();

        private OrganizationCategory? _selectedOrganizationCategory;

        private bool _isLoded = false;
        public bool _hasModifiedCategory => _modifiedOrganizationCategories.Any();
        public OrganizationCategoryListViewModel
            (
                IOrganizationCategoryRepository? organizationCategoryRepository
            )
        {
            _organizationCategoryRepository = organizationCategoryRepository;
        }

        public bool IsLoded => _isLoded;
        public List<OrganizationCategory> OrganizationCategories => _organizationCategories is not null ? _organizationCategories : new List<OrganizationCategory>();
        public int NumberOfOrganizationCategories => OrganizationCategories.Count; 

        public bool SaveDisabled => !_hasModifiedCategory;
        public async Task GetCategoriesAsync()
        {
            if (_organizationCategoryRepository is not null)
            {
                _organizationCategories = await _organizationCategoryRepository.SelectAsync();
                _isLoded = true;
            }
        }

        public async Task Save()
        {
            if (_organizationCategoryRepository is null)
                throw new Exception("Adatok mentése nem lehetséges!");
            else
            {
                Response response = await _organizationCategoryRepository.SaveOrganizationCategories(_modifiedOrganizationCategories);
                if (response.HasError)
                    throw new Exception(response.Error);
            }            
        }
        public void SetNewSelectedCategory(OrganizationCategory newSelectedCategory)
        {
            _selectedOrganizationCategory = newSelectedCategory;
        }

        public void StartEditingCategory(OrganizationCategory editedCategory)
        {
            _editedCategory = editedCategory;
        }

        public void AddToEditedCategory(OrganizationCategory editedCategory)
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

        private bool IsModifiedCategorySameAsTheOriganl(OrganizationCategory modifiedCategory)
        {
            OrganizationCategory? orginalOrganizationCategory = _organizationCategories?.Find(category => category.Id == modifiedCategory.Id);
            return orginalOrganizationCategory != null && orginalOrganizationCategory.Equals(modifiedCategory);
        }
    }
}
