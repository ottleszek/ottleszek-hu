using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.ViewModels.OrganizationCategories
{
    public interface IOrganizationCategoryListViewModel
    {
        List<OrganizationCategoryDto> OrganizationCategories { get; }
        public Task Save();
        int NumberOfOrganizationCategories { get; }
        bool IsLoded { get; }
        bool SaveDisabled { get; }
        Task GetCategoriesAsync();
        void StartEditingCategory(OrganizationCategoryDto editedCategory);
        void SetNewSelectedCategory(OrganizationCategoryDto newSelectedCategory);
        void AddToEditedCategory(OrganizationCategoryDto editedCategory);
    }
}
