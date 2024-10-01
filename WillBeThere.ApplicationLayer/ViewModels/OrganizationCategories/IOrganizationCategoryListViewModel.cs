using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.ViewModels.OrganizationCategories
{
    public interface IOrganizationCategoryListViewModel
    {
        List<OrganizationCategory> OrganizationCategories { get; }
        int NumberOfOrganizationCategories { get; }
        bool IsLoded { get; }
        Task GetCategoriesAsync();
        void StartEditingCategory(OrganizationCategory editedCategory);
        void SetNewSelectedCategory(OrganizationCategory newSelectedCategory);
        void AddToEditedCategory(OrganizationCategory editedCategory);
    }
}
